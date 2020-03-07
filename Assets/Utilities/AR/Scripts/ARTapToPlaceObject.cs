using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class ARTapToPlaceObject : MonoBehaviour
{
    // Back button
    public GameObject backButton;
    public GameObject doneButton;
    // What will spawn
    public GameObject gameObjectToInstantiate;
    //public PlaceAtLocation placeAtLocation;
    private GameObject spawnedObject;
    // To detect touch
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    // "touches"
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake() {
        doneButton.SetActive(false);
        // Required above so safe to use
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition) {
        if(Input.touchCount > 0) {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        // Takes touch position and static list 'hits' and detects if inside plane that AR detected
        if(_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon)) {
            var hitPose = hits[0].pose;

            // If there is an object already then move it etc. (could limit number and all that here)
            if(spawnedObject == null) {
                spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
                doneButton.SetActive(true);
            } else {
                spawnedObject.transform.position = hitPose.position;
                doneButton.SetActive(true);
                //UpdatePlacedObjectsLocation();
            }


        }
    }
}
