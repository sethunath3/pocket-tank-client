using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketTank.Shell
{
    public class ShellView : MonoBehaviour
    {
        private Rigidbody2D rigidbody;
        private ShellController controller;
        private void Start() 
        {
            rigidbody = gameObject.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(gameObject.transform.right*12, ForceMode2D.Impulse);
            
        }

        public void SetController(ShellController _controller)
        {
            controller = _controller;
        }

        public void ProjectShell(Vector3 _position, Quaternion _angle)
        {
            gameObject.transform.position = _position;
            gameObject.transform.rotation = _angle;
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            controller.CollidedWith(other);
        }

        public void DestroyView()
        {
            Destroy(gameObject);
        }

        public Vector2 GetPosition()
        {
            return gameObject.transform.position;
        }
        public int GetLayer()
        {
            return gameObject.layer;
        }
    }
}
