using AIR.UnityTestPilot.Interactions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace UnityTestPilotTests {
    
    [TestFixture]
    public class UiElementStateTests {
        
        const string TEST_NAME = "Test";
        private GameObject _go;

        [SetUp]
        public void SetUp() {
            _go = new GameObject(TEST_NAME);
        }

        [TearDown]
        public void TearDown() {
            GameObject.DestroyImmediate(_go);
        }

        [Test]
        public void Name_ElementIsNotGo_ShowsGoName() {
            
            // Arrange
            var button = _go.AddComponent<Button>();
            var element = new UiElement(button);
            
            // Act
            var buttonName = element.Name;
            
            // Assert
            Assert.AreEqual( buttonName, TEST_NAME );
        }

        [Test]
        public void ActiveInHierarchy_ActiveState_CorrectActivity(
            [Values(true, false)]bool expectedActive
        ) {

            // Arrange
            _go.SetActive(expectedActive);
            var element = new UiElement(_go);
            
            // Act
            var actualActive = element.ActiveInHierarchy;

            // Assert
            Assert.AreEqual(expectedActive, actualActive);
        }

    }
    
}