using OpenQA.Selenium;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Edge;

namespace MicrosoftRegard
{
    class Program
    {
        static void Main(string[] args)
        {
            var cvc = EdgeDriverService.CreateDefaultService();
            EdgeOptions optionsb = new EdgeOptions();
            optionsb.AddArguments("lang=zh_CN.UTF-8");
            // 禁用图片
            optionsb.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            // GPU加速可能会导致Chrome出现黑屏及CPU占用率过高,所以禁用
            optionsb.AddArgument("--disable-gpu");
            //不显示浏览器，无头模式
            //optionsb.AddArgument("--headless");
            optionsb.AddArgument("--start-maximized");
            using (IWebDriver drive = new EdgeDriver(cvc, optionsb))
            {
                drive.Navigate().GoToUrl("https://cn.bing.com/");
                Thread.Sleep(5 * 1000);
                try
                {
                    var k = drive.FindElement(By.Id("id_s"));
                    if (k != null)
                        k.Click();
                }
                catch (Exception)
                {
                    try
                    {
                        var k = drive.FindElement(By.Id("id_a"));
                        if (k != null)
                            k.Click();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                for (int i = 0; i < 40; i++)
                {
                    drive.Navigate().GoToUrl("https://cn.bing.com/search?q=" + DateTime.Now.Second + " " + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss")+
                                             "&qs=n&form=QBRE&sp=-1&pq=1231&sc=10-4&sk=&cvid=F55445203C7246E88ACF331B644EE1F7&ghsh=0&ghacc=0&ghpl=");
                    Thread.Sleep(2 * 1000);
                    try
                    {
                        var k = drive.FindElement(By.Id("id_a"));
                        if (k != null)
                            k.Click();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                    Thread.Sleep(1 * 1000);
                }
            }

            //var options = new EdgeOptions();
            //options.AddArgument("headless");
            //var service = EdgeDriverService.CreateDefaultService(@".", "msedgedriver.exe");
            //var driver = new EdgeDriver(service, options);
            var cdSvc = EdgeDriverService.CreateDefaultService();
            cdSvc.HideCommandPromptWindow = true;
            ChromiumMobileEmulationDeviceSettings CMEDS = new ChromiumMobileEmulationDeviceSettings();
            CMEDS.Width = 320; //设置窗体显示宽高
            CMEDS.Height = 800;
            CMEDS.PixelRatio = 1.0;
            CMEDS.UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5376e Safari/8536.25";
            EdgeOptions options = new EdgeOptions();
            options.AddArguments("lang=zh_CN.UTF-8");
            //不显示浏览器，无头模式
            //options.AddArgument("--headless");
            options.EnableMobileEmulation(CMEDS);
            // 禁用图片
            //options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);
            // GPU加速可能会导致Chrome出现黑屏及CPU占用率过高,所以禁用
            options.AddArgument("--disable-gpu");
            options.AddArgument("--start-maximized");
            using (IWebDriver driver = new EdgeDriver(cdSvc, options))
            {

                driver.Navigate().GoToUrl("https://cn.bing.com/");
                Thread.Sleep(5 * 1000);
                try
                {
                    var k = driver.FindElement(By.Id("mHamburger"));
                    if (k != null)
                        k.Click();
                }
                catch (Exception)
                {
                    // ignored
                }
                Thread.Sleep(3 * 1000);
                try
                {
                    var k = driver.FindElement(By.Id("hb_s"));
                    if (k != null)
                        k.Click();
                }
                catch (Exception)
                {
                    // ignored
                }
                Thread.Sleep(2 * 1000);
                for (int i = 0; i < 30; i++)
                {
                    driver.Navigate().GoToUrl("https://cn.bing.com/search?q=" + DateTime.Now.Second + " "+ DateTime.Now.ToString("yyy-MM-dd HH:mm:ss")+"&qs=n&form=QBRE&sp=-1&pq=1231&sc=10-4&sk=&cvid=F55445203C7246E88ACF331B644EE1F7&ghsh=0&ghacc=0&ghpl=");
                    Thread.Sleep(2 * 1000);
                }
            }
        }
    }
}
