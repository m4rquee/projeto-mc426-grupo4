using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class StageTest
    {
        [UnityTest]
        public IEnumerator PlaceTower()
        {
            SceneManager.LoadScene(ScenesObject.getStage());
            yield return null;

            // Before tower:
            Assert.Null(GameObject.FindWithTag("Tower"));
            Assert.AreEqual(BuildMenu.Cash, BuildMenu.StartCash);

            var gridSquare = GameObject.FindWithTag("GridSquare");
            var towerFire = gridSquare.GetComponent<TowerPlacer>();

            // Tower not selected:
            var tower = towerFire.CreateTower();
            Assert.Null(tower);
            
            
            // Tower selected:
            var buildMenu = GameObject.Find("Main Camera").GetComponent<BuildMenu>();
            BuildMenu.Cur = buildMenu.towers[1];
            tower = towerFire.CreateTower();
            yield return null;
            
            var cash = GameObject.Find("Cash").GetComponent<ShowCashScript>();

            // After tower:
            Assert.NotNull(tower);
            Assert.AreEqual(gridSquare.transform.position, tower.transform.position);
            Assert.AreEqual(BuildMenu.Cash, Convert.ToInt32(cash.GetText()));
        }
    }
}