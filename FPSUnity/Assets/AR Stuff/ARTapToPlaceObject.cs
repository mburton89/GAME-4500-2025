using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Unity.XR.CoreUtils;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementIndicator;
    ARRaycastManager arRaycastManager;
    Pose placementPose;
    bool placementPoseIsValid;

    private List<Transform> placedSpawnPoints = new List<Transform>();
    private bool gameStarted = false;

    public int spawnPointsToPlace;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (gameStarted) return; // No more placements after game starts

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

        if (placedSpawnPoints.Count == spawnPointsToPlace)
        {
            ZombieSpawner.Instance.SetARSpawnPoints(placedSpawnPoints);
            ZombieSpawner.Instance.SpawnWaveOfZombies(); // Starts Wave 1 with 1 zombie
            placementIndicator.SetActive(false);
            gameStarted = true;

            HideMesh[] meshesToHide = FindObjectsOfType<HideMesh>();

            foreach (HideMesh mesh in meshesToHide)
            { 
                mesh.Hide();
            }
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
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon); // Modern trackable type

        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }
}