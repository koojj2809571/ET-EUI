using System.IO;

namespace ET
{
    public class AfterCreateZoneScene_AddComponent: AEvent<EventType.AfterCreateZoneScene>
    {
        protected override  void Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            zoneScene.AddComponent<UIComponent>();
            zoneScene.AddComponent<UIPathComponent>();
            zoneScene.AddComponent<UIEventComponent>();
            zoneScene.AddComponent<RedDotComponent>();
            zoneScene.AddComponent<ResourcesLoaderComponent>();
        
            zoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Login);

            // zoneScene.AddComponent<CarsComponent>();
            //
            // Log.Debug("Before Test");
            // Test(zoneScene).Coroutine();
            // Log.Debug("After Test");
        }

        public async ETTask Test(Scene zoneScene)
        {
            // Car car = zoneScene.GetComponent<CarsComponent>().AddChild<Car>();
            // car.AddComponent<WheelComponent>();
            // car.AddComponent<ChassisComponent>();
            // car.AddComponent<EngineComponent>();
            // car.AddComponent<CarBodyComponent>();
            // car.Run();

            Log.Debug("Enter Test");
            await TimerComponent.Instance.WaitAsync(3000);
            Log.Debug("Three seconds later");
            // car.Dispose();
            int result = await this.Test2();
            Log.Debug($"Result: {result}");
        }

        public async ETTask<int> Test2()
        {
            await TimerComponent.Instance.WaitAsync(1000);
            return 100;
        }
    }
}