using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject gamePiecePrefab;
    public GameObject placementIndicator;
    ARRaycastManager arRaycastManager;
    Pose placementPose;
    bool placementPoseIsValid;

    // Start is called before the first frame update
    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceGamePiece();
        }
    }

    void PlaceGamePiece()
    { 
        Instantiate(gamePiecePrefab, placementPose.position, placementPose.rotation);
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose; //stores fist succesfful raycast point data into our Pose object

            //TODO Indicator Rotation Stuff
        }

    }

    void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        { 
            placementIndicator.SetActive(false);
        }
    }
}
