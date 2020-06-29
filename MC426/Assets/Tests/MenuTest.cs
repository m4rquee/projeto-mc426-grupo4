using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Diagnostics;

namespace Tests
{
    public class MenuTest
    {               
        [UnityTest]
        public IEnumerator TestPlayGame()
        {
        string stageSelectorName = ScenesObject.getStageSelector();

        Assert.IsFalse(SceneManager.GetSceneByName(stageSelectorName).IsValid());

        SceneManager.LoadScene(ScenesObject.getMenu());
        yield return null;

        var gameObject = GameObject.FindWithTag(ScenesObject.getMenu());

        MainMenu menu = gameObject.GetComponent<MainMenu>();
        menu.PlayGame();
        Assert.IsTrue(SceneManager.GetSceneByName(stageSelectorName).IsValid());
        }
    }
}
