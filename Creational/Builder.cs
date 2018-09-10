// нашел пример в интернете и немного переделал https://www.codeproject.com/Articles/470476/Understanding-and-Implementing-Builder-Pattern-in
namespace PatternTest
{
    internal enum ScreenType
    {
        ScreenType_TOUCH_CAPACITIVE,
        ScreenType_TOUCH_RESISTIVE,
        ScreenType_NON_TOUCH
    };

    internal enum Battery
    {
        MAH_1000,
        MAH_1500,
        MAH_2000
    };

    internal enum OperatingSystem
    {
        ANDROID,
        WINDOWS_MOBILE,
        WINDOWS_PHONE,
        SYMBIAN
    };

    internal enum Stylus
    {
        YES,
        NO
    };

    internal sealed class MobilePhone
    {
        public string PhoneName { get; set; }
        public ScreenType PhoneScreen { get; set; }
        public Battery PhoneBattery { get; set; }
        public OperatingSystem PhoneOS { get; set; }
        public Stylus PhoneStylus { get; set; }

        public MobilePhone(string name)
        {
            PhoneName = name;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nScreen: {1}\nBattery {2}\nOS: {3}\nStylus: {4}",
                PhoneName, PhoneScreen, PhoneBattery, PhoneOS, PhoneStylus);
        }
    }

    interface IPhoneBuilder
    {
        void BuildScreen();
        void BuildBattery();
        void BuildOS();
        void BuildStylus();
        MobilePhone Phone { get; }
    }

    internal sealed class AndroidPhoneBuilder : IPhoneBuilder
    {
        public MobilePhone Phone { get; }

        public AndroidPhoneBuilder()
        {
            Phone = new MobilePhone("Android Phone");
        }

        public void BuildScreen()
        {
            Phone.PhoneScreen = ScreenType.ScreenType_TOUCH_RESISTIVE;
        }

        public void BuildBattery()
        {
            Phone.PhoneBattery = Battery.MAH_1500;
        }

        public void BuildOS()
        {
            Phone.PhoneOS = OperatingSystem.ANDROID;
        }

        public void BuildStylus()
        {
            Phone.PhoneStylus = Stylus.YES;
        }        
    }

    internal sealed class WindowsPhoneBuilder : IPhoneBuilder
    {
        public MobilePhone Phone { get; set; }

        public WindowsPhoneBuilder()
        {
            Phone = new MobilePhone("Windows Phone");
        }

        public void BuildScreen()
        {
            Phone.PhoneScreen = ScreenType.ScreenType_TOUCH_CAPACITIVE;
        }

        public void BuildBattery()
        {
            Phone.PhoneBattery = Battery.MAH_2000;
        }

        public void BuildOS()
        {
            Phone.PhoneOS = OperatingSystem.WINDOWS_PHONE;
        }

        public void BuildStylus()
        {
            Phone.PhoneStylus = Stylus.NO;
        }
    }

    internal sealed class Director
    {
        public void Construct(IPhoneBuilder phoneBuilder)
        {
            phoneBuilder.BuildBattery();
            phoneBuilder.BuildOS();
            phoneBuilder.BuildScreen();
            phoneBuilder.BuildStylus();
        }
    }
}
