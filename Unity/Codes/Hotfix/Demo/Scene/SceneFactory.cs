using System.Diagnostics;
using ET.EventType;

namespace ET
{
    public static class SceneFactory
    {
        public static Scene CreateZoneScene(int zone, string name, Entity parent)
        {
            Scene zoneScene = EntitySceneFactory.CreateScene(Game.IdGenerater.GenerateInstanceId(), zone, SceneType.Zone, name, parent);
            zoneScene.AddComponent<ZoneSceneFlagComponent>();
            zoneScene.AddComponent<NetKcpComponent, int>(SessionStreamDispatcherType.SessionStreamDispatcherClientOuter);
			zoneScene.AddComponent<CurrentScenesComponent>();
            zoneScene.AddComponent<ObjectWait>();
            zoneScene.AddComponent<PlayerComponent>();
            
            Game.EventSystem.Publish(new AfterCreateZoneScene() {ZoneScene = zoneScene});
            Log.Debug("Before TestEvent Punlish");
            Game.EventSystem.Publish(new TestEvent(){ZoneScene = zoneScene});
            Game.EventSystem.PublishAsync(new TestEventAsync(){ZoneScene = zoneScene}).Coroutine();
            Log.Debug("After TestEvent Punlish");

            TestEventClass.Instance.ZoneScene = zoneScene;
            Game.EventSystem.PublishClass(TestEventClass.Instance);
            return zoneScene;
        }
        
        public static Scene CreateCurrentScene(long id, int zone, string name, CurrentScenesComponent currentScenesComponent)
        {
            Scene currentScene = EntitySceneFactory.CreateScene(id, IdGenerater.Instance.GenerateInstanceId(), zone, SceneType.Current, name, currentScenesComponent);
            currentScenesComponent.Scene = currentScene;
            
            Game.EventSystem.Publish(new EventType.AfterCreateCurrentScene() {CurrentScene = currentScene});
            return currentScene;
        }
        
        
    }
}