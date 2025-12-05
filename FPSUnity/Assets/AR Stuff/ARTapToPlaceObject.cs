using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using Unity.XR.CoreUtils;
using System;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;

    ARRaycastManager arRaycastManager;

    Pose placementPose; //Pose == Position and Rotation of 3D point in the real world
    bool placementPoseIsValid;

    public int numberOfSpawnPointsToPlace = 5;
    public List<Transform> placedSpawnPoints = new List<Transform>();

    public bool gameHasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHasStarted) return;

        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        GameObject newSpawnPoint = Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
        placedSpawnPoints.Add(newSpawnPoint.transform);

        if (placedSpawnPoints.Count == numberOfSpawnPointsToPlace)
        {
            //TODO: Tell Zombie Spawner what the spawn points are
            ZombieSpawner.Instance.SetARSpawnPoints(placedSpawnPoints);
            ZombieSpawner.Instance.SpawnWaveOfZombies();
            placementIndicator.SetActive(false);
            gameHasStarted = true;
        }
    }

    private void UpdatePlacementIndicator()
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

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
       
        placementPoseIsValid = hits.Count > 0;
        
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            //new rotation based on camera rotation so its not rotating in weird directions
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}
