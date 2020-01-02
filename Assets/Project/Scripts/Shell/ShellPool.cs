using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketTank.Generics;

namespace PocketTank.Shell
{
    public class ShellPool : GenericPool<ShellController>
    {
        private ShellView shellPrefab;
        public ShellPool(ShellView _shellPrefab)
        {
            shellPrefab = _shellPrefab;
        }

        public override ShellController CreateNewItem()
        {
            ShellController shell = new ShellController(shellPrefab);
            return shell;
        }

        public ShellController GetShellFromPool()
        {
            return GetItem();
        }
    }
}
