using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace AIR.UnityDriver {

    // public class GuiIntegrationTestExample {
    //     
    //     [Test]
    //     async void DiggerTeethView_OnToothlossDetected_ShowsGETAnomalyPopup() {
    //         
    //         // Arrange
    //         var mockToothlossService = new MockToothlossService();
    //         CondUIt.SubstituteService<IToothlossService>(mockToothlossService);
    //         var agent = new NativeUnityDriverAgent();
    //         using (var driver = new UnityDriver(agent)) {
    //             var waitView = new UnityDriverWait(driver, TimeSpan.FromSeconds(1));
    //             await waitView.Until(d => d.ActivateView<DiggerTeethView>());
    //             
    //             //Act
    //             mockToothlossService.OnToothlossDetected?.Invoke();
    //             var waitPopup = new UnityDriverWait(driver, TimeSpan.FromSeconds(1));
    //             var byPopupQuery = By.TypeWithName<CanvasRenderer>("GETAnomalyPopup_LayoutElement");
    //             var getAnomalyPopup = await waitPopup.Until(d => d.FindUi(byPopupQuery));
    //             
    //             // Assert
    //             Assert.IsTrue(getAnomalyPopup.IsActiveAndEnabled);
    //         }
    //
    //     }
    //
    //
    //     [Test]
    //     async void SettingsView_ClickedAndHeld_ShowsAdminLoginKeypad(){
    //
    //         // Arrange
    //         var agent = new RemoteUnityDriverAgent();
    //         const int REPLAY_MULTIPLIER = 100;
    //         agent.SetTimeScale(REPLAY_MULTIPLIER);
    //         using (var driver = new UnityDriver(agent)) {
    //
    //             // Act
    //             var settingsButton = driver.FindUi(By.TypeWithName<Button>("Settings_Button"));
    //             settingsButton.SimulateClickDown();
    //
    //             const int HOLD_TIME = 5, BUFFER = 1;
    //             var wait = new UnityDriverWait(driver, timeout: TimeSpan.FromSeconds(HOLD_TIME + BUFFER));
    //
    //             // Assert
    //             var adminLogin = await wait.Until(d => d.FindUi(By.Type<AdminLoginView>()));
    //             Assert.IsTrue(adminLogin.IsActiveAndEnabled);
    //         
    //         }
    //
    //     }
    //     
    //     [Test]
    //     async void AboutView_OpenedThenClosed_IsNotActive() {
    //         
    //         // Arrange
    //         var agent = new RemoteUnityDriverAgent();
    //         using (var driver = new UnityDriver(agent)) {
    //             
    //             var crLogo = driver.FindUi(By.TypeWithName<Image>("CRLogo"));
    //             crLogo.SimulateClick();
    //
    //             // Act
    //             var backButton = driver.FindUi(By.TypeWithName<Button>("Back_Button"));
    //             backButton.SimulateClick();
    //
    //             // Assert
    //             var menuBarView = driver.FindUi(By.Type<MenuBarView>());
    //             Assert.IsFalse(menuBarView.IsActiveAndEnabled);
    //             
    //         }
    //         
    //     }
    //     
    // }

    public class UnityDriver : IDisposable {
        
        private IUnityDriverAgent _agent;

        public UnityDriver(IUnityDriverAgent agent) {
            _agent = agent;
        }

        public UiElement FindUi(ElementQuery query) {
            return FindUis(query).First();
        }
        
        public UiElement[] FindUis(ElementQuery query) {
            var element = _agent.Query(query);
            return element.Result;
        }

        public void Dispose() {
            _agent.Shutdown();
        }

    }

    public static class By {

        public static ElementQuery Name(string name) {
            return new NamedElementQuery(name);
        }

        public static ElementQuery TypeWithName<T>(string name) {
            return new TypedElementQuery(typeof(T), name);
        }

        public static ElementQuery Type<T>() {
            return new TypedElementQuery(typeof(T));
        }
    }

    public abstract class ElementQuery {
        
        private UiElement _foundElement;

        public abstract void Search();

    }

    public class NamedElementQuery : ElementQuery {

        private string _queryName;
        public NamedElementQuery(string name) {
            _queryName = name;
        }

        public override void Search() {
            throw new NotImplementedException(
                "Find UI Element by name.");
        }
    }
    
    public class TypedElementQuery : ElementQuery {

        private Type _queryType;
        private string _queryName;
        
        public TypedElementQuery(Type type, string name) {
            _queryType = type;
            _queryName = name;
        }

        public TypedElementQuery(Type type) {
            _queryType = type;
        }

        public override void Search() {
            throw new NotImplementedException(
                "Find UI Element by type and name if given.");
        }
    }

    public class UiElement {
        public bool IsActiveAndEnabled { get; set; }
        public void SimulateClick (){ }
        public void SimulateClickDown() { }
        public void SimulateClickUp() { }
        public void SimulateKeys(KeyCode[] keys) { }
        public void SimulateKeys(string keys) { }
    }

    public class UnityDriverWait {
        public UnityDriverWait(UnityDriver driver, TimeSpan timeout){ }
        public void Until(Func<UnityDriver, bool> until){ }
        public Task<UiElement> Until(Func<UnityDriver, UiElement> until) { return null; }
        public UiElement UntilSync(Func<UnityDriver, UiElement> until) { return null; }
    }

    public interface IUnityDriverAgent {
        Task<UiElement[]> Query(ElementQuery query);
        void Shutdown();
        void SetTimeScale(float timescale);
    }

    class RemoteUnityDriverAgent : IUnityDriverAgent {
        
        public async void Shutdown() {
            throw new NotImplementedException(
                "Call ClientUnityDriver over tachyon.");
        }

        public void SetTimeScale(float timescale) {
            throw new NotImplementedException(
                "Call ClientDriver over tachyon.");
        }

        public async Task<UiElement[]> Query(ElementQuery query) {
            throw new NotImplementedException(
                "Call ClientUnityDriver over tachyon.");
        }
    }

    class ClientUnityDriverAgent : IUnityDriverAgent {
        
        private NativeUnityDriverAgent _nativeDriver;

        public void SetTimeScale(float timescale) {
            _nativeDriver.SetTimeScale(timescale);
        }

        // Called over tachyon network.
        public void Shutdown() {
            _nativeDriver.Shutdown();
        }

        // Called over tachyon network.
        public Task<UiElement[]> Query(ElementQuery query) {
            return _nativeDriver.Query(query);
        }
    }

    class NativeUnityDriverAgent : IUnityDriverAgent {
        public void Shutdown() {
            throw new NotImplementedException(
                "Restart application state.");
        }

        public void SetTimeScale(float timescale) {
            throw new NotImplementedException(
                "Change Time.timeScale for faster test replay.");
        }

        public Task<UiElement[]> Query(ElementQuery query) {
            throw new NotImplementedException(
                "Interact with CondUIt to perform query.");
        }

    }

}
