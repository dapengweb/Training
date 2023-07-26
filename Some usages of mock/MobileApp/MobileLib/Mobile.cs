namespace MobileLib
{
    public class Mobile
    {
        private ICamera camera = null;

        public Mobile()
        {
            camera = new Camera();
        }

        public Mobile(ICamera camera)
        {
            this.camera = camera;
        }

        public bool PowerOn()
        {
            Console.WriteLine("mobile poweron method invked...");
            return camera.ON();
        }
    }
}