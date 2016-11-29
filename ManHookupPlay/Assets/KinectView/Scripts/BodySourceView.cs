﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Kinect = Windows.Kinect;

using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class BodySourceView : MonoBehaviour
{
    public Material BoneMaterial;
    public GameObject BodySourceManager;

    private Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
    private BodySourceManager _BodyManager;

    private Dictionary<Kinect.JointType, Kinect.JointType> _BoneMap = new Dictionary<Kinect.JointType, Kinect.JointType>()
    {
        { Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
        { Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
        { Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
        { Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },

        { Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
        { Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
        { Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
        { Kinect.JointType.HipRight, Kinect.JointType.SpineBase },

        { Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
        { Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
        { Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
        { Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },

        { Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
        { Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
        { Kinect.JointType.HandRight, Kinect.JointType.WristRight },
        { Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
        { Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
        { Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },

        { Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
        { Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
        { Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
        { Kinect.JointType.Neck, Kinect.JointType.Head },
    };

    private Dictionary<Kinect.JointType, float> jointSizes = new Dictionary<Kinect.JointType, float>() {
        { Kinect.JointType.Head, 3.0f },
        { Kinect.JointType.Neck, 2.0f },

    };

    enum Mode { Recording, Playing };
    private Mode mode = Mode.Recording;

    void Update () 
    {
        if (mode == Mode.Recording) {
            if (BodySourceManager == null)
            {
                return;
            }

            _BodyManager = BodySourceManager.GetComponent<BodySourceManager>();
            if (_BodyManager == null)
            {
                return;
            }

            Kinect.Body[] data = _BodyManager.GetData();
            if (data == null)
            {
                return;
            }

            List<ulong> trackedIds = new List<ulong>();
            foreach (var body in data)
            {
                if (body == null)
                {
                    continue;
                }

                if (body.IsTracked)
                {
                    trackedIds.Add(body.TrackingId);
                }
            }

            List<ulong> knownIds = new List<ulong>(_Bodies.Keys);

            // First delete untracked bodies
            foreach (ulong trackingId in knownIds)
            {
                if (!trackedIds.Contains(trackingId))
                {
                    Destroy(_Bodies[trackingId]);
                    _Bodies.Remove(trackingId);
                }
            }

            NewFrame();
            foreach (var body in data)
            {
                if (body == null)
                {
                    continue;
                }

                if (body.IsTracked)
                {
                    if (!_Bodies.ContainsKey(body.TrackingId))
                    {
                        _Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                    }

                    RefreshBodyObject(body, _Bodies[body.TrackingId]);
                    AddBodyToFrame(body);
                }
            }
            WriteFrame();

        }
        else
        {
            // ReadNextFrame(body);   
        }
    }

    private BodyRecording.Frame frame;
    private void NewFrame()
    {
        frame = new BodyRecording.Frame();
    }

    private XmlSerializer serializer = new XmlSerializer(typeof(BodyRecording));
    private BodyRecording xmlRecording = new BodyRecording();

    private BodyRecording.Frame.Body AddBodyToFrame(Kinect.Body body)
    {
        var xmlBody = new BodyRecording.Frame.Body();
        frame.bodies.Add(xmlBody);
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            var vec = GetVector3FromJoint(body.Joints[jt]);
            xmlBody.JointPositions[(int)jt] = vec;
        }
        return xmlBody;
    }

    private void WriteFrame()
    {
        string filename = Path.Combine(Application.persistentDataPath, "body_recording.xml");
        using (var stream = new FileStream(filename, FileMode.OpenOrCreate))
        {
            xmlRecording.frames.Add(frame);
            Debug.Log("Writing " + filename);
            serializer.Serialize(stream, xmlRecording);
        }
    }


    private GameObject CreateBodyObject(ulong id)
    {
        GameObject body = new GameObject("Body:" + id);

        //var jointTypeCollection = JointTypeContainer.Load(Path.Combine(Application.dataPath, "jointypes.xml"));
        //var xmlData = ""; 

        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            GameObject jointObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
            LineRenderer lr = jointObj.AddComponent<LineRenderer>();
            lr.SetVertexCount(2);
            lr.material = BoneMaterial;
            lr.SetWidth(0.5f, 0.5f);

            float scale = 2f;
            if (jointSizes.ContainsKey(jt)) {
                scale = jointSizes[jt];
            }
            jointObj.transform.localScale = new Vector3(scale, scale, scale);
            jointObj.name = jt.ToString();
            jointObj.transform.parent = body.transform;

            //xmlData = @"<JointTypeCollection><JointTypesXML><JointTypeNameXML>" + jt + "</JointTypeNameXML></JointTypesXML></JointTypeCollectionXML>";
      

            
        }

        //Debug.Log(xmlData);
        //var jointTypeCollection2 = JointTypeContainer.LoadFromText(xmlData);

        //Debug.Log(jointTypeCollection);
        //Debug.Log(jointTypeCollection2);

        //jointTypeCollection.Save(Path.Combine(Application.persistentDataPath, "jointypes.xml"));


        return body;
    }



    private void RefreshBodyObject(Kinect.Body body, GameObject bodyObject)
    {
        for (Kinect.JointType jt = Kinect.JointType.SpineBase; jt <= Kinect.JointType.ThumbRight; jt++)
        {
            Kinect.Joint sourceJoint = body.Joints[jt];
            Kinect.Joint? targetJoint = null;
            
            if(_BoneMap.ContainsKey(jt))
            {
                targetJoint = body.Joints[_BoneMap[jt]];
            }
            
            Transform jointObj = bodyObject.transform.FindChild(jt.ToString());
            var vec = GetVector3FromJoint(sourceJoint);
            jointObj.localPosition = vec;

            
            LineRenderer lr = jointObj.GetComponent<LineRenderer>();
            if(targetJoint.HasValue)
            {
                lr.SetPosition(0, jointObj.localPosition);
                lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value));
                lr.SetColors(GetColorForState (sourceJoint.TrackingState), GetColorForState(targetJoint.Value.TrackingState));
            }
            else
            {
                lr.enabled = false;
            }
        }
       
    }
    
    private static Color GetColorForState(Kinect.TrackingState state)
    {
        switch (state)
        {
        case Kinect.TrackingState.Tracked:
            return Color.green;

        case Kinect.TrackingState.Inferred:
            return Color.red;

        default:
            return Color.black;
        }
    }
    
    private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}