using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class TestStageSelector
    {
        //Armazenar aqui o valor máximo de stages para caso isso altere não ter que alterar no código todo
        private int stagesQuantity = 10;

        // Test #1 - Fase 1 deve ser liberada corretamente com unlockedStages = 0
        [UnityTest]
        public IEnumerator _TestStagesEqualsTo0()
        {
            SceneManager.LoadScene(ScenesObject.getStageSelector());
            yield return null;
            StageSelectorStagesLoader.setUnlockedStages(0);
            yield return null;
            StageSelectorScreenController fase = GameObject.Find("ScrollableScreen").GetComponent<StageSelectorScreenController>();
            Assert.IsFalse(fase.IsStageBlocked(0));
        }

        // Test #1 - Fase 1 deve ser liberada corretamente e Fase 2 deve ser bloqueada com unlockedStages = 1
        [UnityTest]
        public IEnumerator _TestStagesEqualsTo1()
        {
            SceneManager.LoadScene(ScenesObject.getStageSelector());
            yield return null;
            StageSelectorStagesLoader.setUnlockedStages(1);
            yield return null;
            StageSelectorScreenController fase = GameObject.Find("ScrollableScreen").GetComponent<StageSelectorScreenController>();
            Assert.IsFalse(fase.IsStageBlocked(0));
            Assert.IsTrue(fase.IsStageBlocked(1)); 
        }

        // Test #1 - Fase 1-10 devem ser liberadas corretamente com unlockedStages = 10
        [UnityTest]
        public IEnumerator _TestStagesEqualsTo10()
        {
            SceneManager.LoadScene(ScenesObject.getStageSelector());
            yield return null;
            StageSelectorStagesLoader.setUnlockedStages(stagesQuantity);
            yield return null;
            StageSelectorScreenController fase = GameObject.Find("ScrollableScreen").GetComponent<StageSelectorScreenController>();
            for (int i=0; i<stagesQuantity;i++){
                Assert.IsFalse(fase.IsStageBlocked(i));
            }
        }

        // Test #1 - Fase 1-10 devem ser liberadas corretamente com unlockedStages = 11, não deve dar erro
        [UnityTest]
        public IEnumerator _TestStagesEqualsTo11()
        {
            SceneManager.LoadScene(ScenesObject.getStageSelector());
            yield return null;
            StageSelectorStagesLoader.setUnlockedStages(stagesQuantity+1);
            yield return null;
            StageSelectorScreenController fase = GameObject.Find("ScrollableScreen").GetComponent<StageSelectorScreenController>();
            for (int i=0; i<stagesQuantity;i++){
                Assert.IsFalse(fase.IsStageBlocked(i));
            }
        
        }

        // Test #2 - Clicar em fase liberada deve redirecionar para o Stage
        [UnityTest]
        public IEnumerator _TestClickOnPlayableStage()
        {
            SceneManager.LoadScene(ScenesObject.getStageSelector());
            yield return null;
            StageSelectorStagesLoader.setUnlockedStages(3);
            yield return null;
            StageSelectorScreenController fase = GameObject.Find("ScrollableScreen").GetComponent<StageSelectorScreenController>();
            GameObject btnFase = fase.getButton(1);
            Image imageA = btnFase.GetComponent<Image>();
            Assert.AreEqual("imagem_fase",imageA.sprite.name);
            btnFase.GetComponent<Button>().onClick.Invoke();
            yield return null;
            Assert.AreEqual(ScenesObject.getStage(), SceneManager.GetActiveScene().name);
        }

        // Test #3 - Clicar em fase bloqueada deve aparecer mensagem de fase bloqueada
        [UnityTest]
        public IEnumerator _TestClickOnBlockedStage()
        {
            SceneManager.LoadScene(ScenesObject.getStageSelector());
            yield return null;
            StageSelectorStagesLoader.setUnlockedStages(3);
            yield return null;
            StageSelectorScreenController fase = GameObject.Find("ScrollableScreen").GetComponent<StageSelectorScreenController>();
            GameObject btnFase = fase.getButton(3);
            Image imageA = btnFase.GetComponent<Image>();
            Assert.AreEqual("imagem_fase_bloqueada",imageA.sprite.name);
            btnFase.GetComponent<Button>().onClick.Invoke();
            yield return null;
            Assert.AreEqual(ScenesObject.getStageSelector(), SceneManager.GetActiveScene().name);
            //TODO: Testar se a mensagem de fase bloqueada aparece
        }
    }
}
