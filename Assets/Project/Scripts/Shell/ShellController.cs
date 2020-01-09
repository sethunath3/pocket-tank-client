using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Game;
using PocketTank.Interfaces;
using PocketTank.Gameplay;
using System;
using PocketTank.Events;

namespace PocketTank.Shell
{
    public class ShellController
    {
        ShellView shellView;
        public ShellController(ShellView shellPrefab)
        {
            shellView = GameObject.Instantiate(shellPrefab);
            shellView.SetController(this);
        }

        public void ProjectShell(Vector3 _position, Quaternion _angle)
        {
            shellView.ProjectShell(_position,  _angle);
        }

        public void CollidedWith(Collision2D collider)
        {
            if(collider.gameObject.layer == (int)GameLayers.Ground)
            {
                ExplodeShell();
            }
            else if(collider.gameObject.layer == (int)GameLayers.PlayerTank && shellView.GetLayer() != 10)
            {
                IDamageable damagableComponent = collider.gameObject.GetComponent<IDamageable>();
                damagableComponent.TakeDamage(10);
                EventService.Instance.PlayerGotHit();
                ExplodeShell();
            }
            else if(collider.gameObject.layer == (int)GameLayers.EnemyTank && shellView.GetLayer() != 13)
            {
                IDamageable damagableComponent = collider.gameObject.GetComponent<IDamageable>();
                damagableComponent.TakeDamage(10);
                EventService.Instance.EnemyGotHit();
                ExplodeShell();
            }
        }

        public void ExplodeShell()
        {
            GameObject explosion = GameObject.Instantiate(GameplayService.Instance.explosionPrefab, shellView.GetPosition(), Quaternion.identity);
            GameObject.Destroy(explosion, 1.5f);
            shellView.DestroyView();
            shellView = null;
        }
    }
}
