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
        private Scene _simulationScene;
        private PhysicsScene _physicsScene;

        [SerializeField]
        private Transform _obsticalesParent;

        private void Start()
        {
            CreatePhysicsScene();
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
            }
        }

        public void SimulateTrajectory(Ball ballPrefab, Vector3 pos, Vector3 velocity)
        {
            var ghostObj = Instantiate(ballPrefab, pos, Quaternion.identity);
            SceneManager.MoveGameObjectToScene(ghostObj.gameObject, _simulationScene);

            ghostObj.Init(velocity, true);
        }
    }
}
