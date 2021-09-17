using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// 2021.9.16
/// </summary>

namespace Main
{
    public class ProjectionGun : MonoBehaviour
    {
        [SerializeField]
        private Transform _obsticalesParent;

        [SerializeField] 
        private LineRenderer _line;

        [SerializeField]
        private int _maxPhysicsFrameIterations = 100;

        private Scene _simulationScene;
        private PhysicsScene _physicsScene;
        private readonly Dictionary<Transform, Transform> _spawnedObjects = new Dictionary<Transform, Transform>();

        private void Start()
        {
            CreatePhysicsScene();
        }

        private void Update()
        {
            foreach (var item in _spawnedObjects)
            {
                item.Value.position = item.Key.position;
                item.Value.rotation = item.Key.rotation;
            }
        }

        void CreatePhysicsScene()
        {
            _simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
            _physicsScene = _simulationScene.GetPhysicsScene();

            foreach(Transform obj in _obsticalesParent)
            {
                var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
                ghostObj.GetComponent<Renderer>().enabled = false;
                SceneManager.MoveGameObjectToScene(ghostObj, _simulationScene);
                if (!ghostObj.isStatic) _spawnedObjects.Add(obj, ghostObj.transform);
            }
        }

        public void SimulateTrajectory(Ball ballPrefab, Vector3 pos, Vector3 velocity)
        {
            var ghostObj = Instantiate(ballPrefab, pos, Quaternion.identity);
            SceneManager.MoveGameObjectToScene(ghostObj.gameObject, _simulationScene);

            ghostObj.Init(velocity, true);

            _line.positionCount = _maxPhysicsFrameIterations;

            for (var i = 0; i < _maxPhysicsFrameIterations; i++)
            {
                _physicsScene.Simulate(Time.fixedDeltaTime);
                _line.SetPosition(i, ghostObj.transform.position);
            }

            Destroy(ghostObj.gameObject);
        }
    }
}
