using Microsoft.AspNetCore.Mvc;
using Auggie_IT_Support_Portal.Models;
using Auggie_IT_Support_Portal.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using Auggie_IT_Support_Portal.ViewModels;



namespace Auggie_IT_Support_Portal.Controllers
{
    public class SupportController : Controller
    {
        public IActionResult UpdateImage()
        {
            var imageSteps = new List<ImageUpdateStep>
            {
                new ImageUpdateStep
                {
                    Title = "Deploy the AUDIT Image from FOG to Device",
                    Description = "Use FOG to deploy the base AUDIT image to the device.",
                },
                new ImageUpdateStep
                {
                    Title = "Make Changes",
                    SubSteps = new List<string>
                    {
                        "Deploy the AUDIT image using Fog.",
                        "Download the Auggie package from Auggie Management.",
                        "Ensure this step is done by the Auggie user for full functionality.",
                        "Run '[packagename].exe Upgrade' in PowerShell where the file was downloaded."
                    }
                },
                new ImageUpdateStep
                {
                    Title = "Run Sysprep",
                    Description = "Navigate to Sysprep and run it with the following options:",
                    SubSteps = new List<string> { "OOBE", "Generalize", "Shutdown" }
                },
                new ImageUpdateStep
                {
                    Title = "Capture the Image",
                    Description = "Capture it to FOG with the format 'Auggie-OOBE-[Client Version]'",
                    Tip = "Example: Auggie-OOBE-2024.2.04.1"
                }
            };

            var afterFlashSteps = new List<Afterflash>
            {
                new Afterflash
                {
                    Title = "Setup Auggie after flashing Windows IoT image",
                    Description = "This section applies after flashing the latest image onto the device and beginning the configuration process. The following steps outline how to set up a fully functional Windows device.",
                    SubSteps = new List<string>
                    {
                        "Rename Device",
                        "Check the Device Manager",
                        "Setup Password for TeamViewer",
                        "Change Lockdown utility settings",
                        "Set default browser to Edge",
                        "Set Activation code or Run Script"
                    },
                    Tip = "Please note: A script will be provided to automate the entire configuration process."
                },
                new Afterflash
                {
                    Title = "Name the Device",
                    Description = "Once the device has been flashed, it will automatically launch into the Windows home page. Enter the five-digit Auggie number into the popup. The Auggie should automatically reboot and change the name.",
                    SubSteps = new List<string>
                    {
                        "Enter Five-Digit Auggie"
                },
                    Tip = "Note: Once the device reboots, you do not need to manually install TeamViewer, ScreenConnect, or Automate—this process is handled automatically."
                },
                new Afterflash
                {
                    Title = "Display Settings",
                    Description = "Right-click on the desktop and select 'Display Settings' to adjust your display options.",
                    SubSteps = new List<string>
                    {
                        "Extend these displays",
                        "Select the smaller screen and check the box at the bottom to set it as your primary display.",
                        "Ensure that the scaling for both screens is set to 100%."
                    }
                },
                new Afterflash
                {
                    Title = "Check Drivers",
                    Description = "Right-click the Start button, choose Device Manager, and check for any warning symbols.",
                    SubSteps = new List<string>
                    {
                        "If you see any warnings, navigate to C:\\Auggie\\Drivers\\Snappy and update the drivers from that location"
                    }
                },
                new Afterflash
                {
                    Title = "TeamViewer",
                    Description = "Once TeamViewer is open, follow these steps:",
                    SubSteps = new List<string>
                    {
                        "Go to C:\\Auggie\\Auggie-info and retrieve the generated password",
                        "In TeamViewer, set password",
                        "Open TeamViewer and set a password. Then, copy the TeamViewer ID, as it will be used later. Next, go to Orien",
                        "Use the same password you set in TeamViewer in Orien—paste it there along with the TeamViewer ID."
                    }
                },
                new Afterflash
                {
                    Title = "Set Lockdown Utility",
                    Description = "Launch 'explorer.exe' and run Lockdown Utility.",
                    SubSteps = new List<string>
                    {
                        "Lockdown Settings:",
                        "i. Enable 'Custom Shell' and 'Embedded Logon'",
                        "Startup Manager:",
                        "i. Enable 'Custom Shell' for 'Auggie' user with 'Restart Shell' action after close.",
                        "ii. Make sure the exe it's launching is: C:\\Auggie\\Software\\StartAuggie.exe.",
                        "iii. Automatic Logon: Enable for 'Auggie' user.",
                        "iv. Advanced Boot Option: Disable Windows Boot Logo and Lockscreen.",
                        "Embedded Logon:",
                        "i. Advanced Boot Option: Disable 'LoginScreen'.",
                        "ii. Enable 'Blocked Shutdown Resolver' (BRDR)",
                        "iii. Only enable 'Task Manager' and 'Power Button'"
                    },
                    Tip = "Reboot and verify that the device is launching correctly."
                },
                new Afterflash
                {
                    Title = "Setup device in ORION",
                    Description = "Access the production environment at manage.auggie.tech and the UAT environment at manage.auggie.uat.",
                    SubSteps = new List<string>
                    {
                        "Activate device in PRD and UAT"
                    }
                }
            };

            var viewModel = new ImageUpdateViewModel
            {
                ImageUpdateSteps = imageSteps,
                AfterFlashSteps = afterFlashSteps
            };

            return View(viewModel);
        }

        //Display Class
        public IActionResult Display()
        {
            var issues = new List<DisplayIssue>
            {

                 new DisplayIssue
                 {
                    Title ="Resolution Problems",
                    AdditionalInfo = "Set to 'Extend these displays', orientation set to 'Landscape (flipped)', and scaling at 100%.",
                    DisplayTips ="If the main screen is set to 150% (default), it will interfere with calibration."

                 },
                new DisplayIssue
                {
                    Title = "Side Screen Not turning On",
                    Lp3Steps = new List<string>
                    {
                        "Check the display cable to ensure it is properly connected on the Latte Panda."
                    },
                    Lp2Steps = new List<string>{
                        "Check the HDMI cable to ensure it's working properly.If that doesn't resolve the issue, the port may be faulty, which means the Panda unit may need to be replaced."
                    }


                },
                new DisplayIssue
                {
                    Title="Flickering Displays",
                    AdditionalInfo = "This may indicate a hardware issue or poor HDMI cable quality.",
                    Lp3Steps = new List<string>
                    {
                        "If either the side screen or main screen flickers, the manufacturer will replace one or both screens."
                    },
                    Lp2Steps=new List<string>
                    {
                        "If the side screen or main screen cable has been replaced and wiggling the cable at the Panda causes the side screen to flicker, the port on the Panda is likely faulty — a Panda replacement will be necessary."
                    }


                },



            };
            return View(issues);
        }

        // Power class

        public IActionResult Power()
        {
            var PowerPage = new List<Power>
            {
                new Power
                {
                    Title ="Expected Actions",
                    Description ="The power button should light up blue, and within 5 to 10 seconds, the Auggie logo should appear, followed by the loading screen:",
                    SubSteps= new List<string>
                    {
                        "This is assuming the Customer installed a battery in the side compartment"
                    }

                },


                new Power
                {
                    Title="Prelimilinary Checks",
                    Description="Before Powering on the Auggie make sure the following has been checked:",
                    SubSteps= new List<string>
                    {
                        "Check for any signs of damage or wear on the batteries, the XT-30 connectors, and the wires.",
                        "The battery being used for calibration is fully charged.",
                        "Ensure the battery is firmly connected using XT-30 connectors to the Auggie wiring harness.",
                        "Ensure that the blue LED on the button illuminates—this confirms that the button is operational and the battery is successfully powering the Power Distribution Board."
                    }
                },
                new Power
                {
                    Title =" No Blue LED When Pressing Power Button - Customer",
                    Description ="Customer On-Site Verification Checklist: ",
                    SubSteps=new List<string>
                    {
                        "Ensure  the battery is properly connected using the XT - 30 connector. ",
                        "Check for any signs of damage or wear on the XT-30 connctor or wires.",
                        "Disconnect the primary battery and connect the  spare battery,the issue may be the primary battery.",
                        "If neither the primary nor spare battery works, try changing both.",
                        "Check the indicators to ensure theh batteries are charging correctly."

                    }
                },
                new Power
                {
                    Title =" No Blue LED When Pressing Power Button - IT tech ",
                    Description =" The IT technician should follow this checklist in addition to the one designated for the customer:",
                    SubSteps=new List<string>
                    {

                        "Check BIOS Settings:Press the Delete key during startup to enter the BIOS. --> Navigate to the Chipset tab. --> Locate the AC Power Loss setting and ensure it is set to 'Power On'.",
                        "If the Panda device does not function with the Auggie but powers on when connected to a C-port, send the device back to the manufacturer for inspection of the PDB board."
                    }
                },
                new Power
                {
                    Title="Blue LED but No Activity On Screen",
                    Description="This may be due to wiring, RTC, or software-related issues:",
                    SubSteps= new List<string>
                    {
                        "Possible signs of RTC/Auto Power-On issues include: The side screen remains black while the target screen cycles through red, g reen, and blue colors.",
                        "Signs of wiring issues: If the blue LED on the power button is on but there is no activity on either screen."
                        ,
                        " It's likely a power-related issue. It's also possible that a wire to either the LP or target screen has been damaged. In such cases, the device should be recalled for inspection. "
                    }
                },
                new Power
                {
                    Title="Blue LED on but both screen are black",
                    Description ="You will need to remotely access the device using ScreenConnect or TeamViewer:",
                    SubSteps=new List<string>
                    {
                        "Once connected to the device, open Backstage and navigate to Resources. In Resource Monitor, go to the Overview tab." +
                        " Locate and select Winlogon.exe, then right-click it and choose 'End Process Tree'."
                        ,"Log in to the Auggie Desktop side. Open Task Manager, locate and end the process eshell.exe,then sign out of the session. "
                    }
                }
            };



            return View(PowerPage);
        }


        public IActionResult Connectivity()
        {
            var NetworkPage = new List<Connectivity>
            {
                new Connectivity
                {
                    Title = "No Networks Found",
                    Description = "This message appears when your device is unable to detect any available Wi-Fi networks. This can be due to the device being out of range, or there may be an issue with the router or wireless signal.",
                    Info = new List<string>
                    {
                        "Ensure the device is within range of a known Wi-Fi network.",
                        "Verify that Wi-Fi is turned on and functioning on your device.",
                        "Check whether other devices can see and connect to the same Wi-Fi network."
                    }
                },
                new Connectivity
                {
                    Title = "Unable to Connect to Network",
                    Description = "This message indicates that your device has detected a Wi-Fi network but cannot establish a connection. The issue may be due to incorrect credentials, network problems, or device-related issues.",
                    Info = new List<string>
                    {
                        "Verify the Wi-Fi network’s status and ensure it is active and functioning.",
                        "Re-enter the Wi-Fi password carefully.",
                        "Restart the Wi-Fi router or access point to refresh the connection.",
                        "Try connecting the device to a different available Wi-Fi network to isolate the issue."
                    }
                },
                new Connectivity
                {
                    Title = "Intermittent or Weak Signal",
                    Description = "This issue occurs when the device experiences a weak or unstable Wi-Fi connection. It can lead to slow internet speeds, dropped connections, or difficulty maintaining a stable link to the network.",
                    Info = new List<string>
                    {
                        "Move the device closer to the Wi-Fi router or access point to improve signal strength.",
                        "Eliminate or reduce physical obstructions between the device and the router."
                    }
                },
                new Connectivity
                {
                    Title = "Network Drops or Disconnects",
                    Description = "This issue occurs when the device experiences a weak or unstable Wi-Fi connection. It can lead to slow internet speeds, dropped connections, or difficulty maintaining a stable link to the network.",
                    Info = new List<string>
                    {
                        "Check for potential interference from nearby devices or networks.",
                        "Restart the Wi-Fi router or access point to refresh and stabilize the network connection."
                    }
                }
            };

            var MoreWifi = new List<AdvConnectity>
            {
                new AdvConnectity
                {
                    Title = "Using Mobile Hotspot:",
                    Description = "Ensure that the customer's network and router settings are properly configured to support system connectivity and access to required services.\nUse a mobile hotspot as a temporary network connection for the device.",
                    Info = new List<string>
                    {
                        "Ensure the hotspot has:\n- A strong and stable cellular signal\n- Sufficient data bandwidth available.",
                        "Program the hotspot with the following known SSID and password:\nSSID: auggie\nPassword: 12345678"
                    },
                    ImageUrl = "/images/wifi.png"
                }
            };

            var Subwifi = new List<AdvSubStep>
            {
                new AdvSubStep
                {
                    Title = "Router Configuration and Device Compatibility",
                    Info = new List<string>
                    {
                        "Verify that the router's firmware is up to date.",
                        "Ask the customer to check the router settings for any restrictions like MAC address filtering or a limited number of devices.",
                        "Run the networktest.ps1 in C:\\Users\\AirPro\\.auggie\\scripts",
                        "You can run this script with the environment as an argument like: '.\\networktest.ps1 prd' or '.\\networktest.ps1 uat'."
                    }
                },
                new AdvSubStep
                {
                    Title = "Important User Notes",
                    Info = new List<string>
                    {
                        "Educate the user about the importance of maintaining a strong Wi-Fi signal and the potential impact of physical barriers and interference.",
                        "Auggie will only connect to an Open or WPA2-PSK network."
                    }
                }
            };

            var viewModel = new ConnectivityViewModel
            {
                NetworkPage = NetworkPage,
                MoreWifi = MoreWifi,
                Subwifi = Subwifi
            };

            return View(viewModel);
        }


        // LED page 
        public IActionResult LED()
        {
            var LedPage = new List<LED>
            {
                new LED
                {
                    Title= "General Information",
                    Description ="LED lights are used to illuminate the target markers during vehicle calibration, enabling the camera to detect them accurately. Power to the LEDs is controlled via a USB relay. When needed, AUGGIE runs a background script—either lighton.ps1 or lightsoff.ps1—to turn the lights on or off accordingly.",
                    Info = "File Location: Below is a list of files used to manage this USB relay and brief description.",
                    ImageUrl = "/images/LED1.png"


                },

                new LED
                {
                    Title="Troubleshooting Tips:",
                    Description="Verify you see the USB relay in Device Manager:",
                    ImageUrl ="/images/LED2.png",
                    Info="Open PowerShell in: C:\\Users\\AirPro\\.auggie\\scripts\\. Run lighton.ps1 and check if the LED lights are on."




                }






            };
            return View(LedPage);
        }
        public IActionResult Other()
        {
            var otherpage = new List<Other>
            {
                new Other
                {
                    Title="Uninstall Auggie Client",
                    Info= new List<String>
                    {
                        "Locate the package that is currently installed on the device. In most cases, a copy can be found in one of your standard software or downloads directories. Open PowerShell in the directory where the package is stored. To do this quickly, hold SHIFT and right-click within the folder to access the “Open PowerShell window here” option.",
                        "Run the .exe with the uninstall argument:"
                    },
                    ImageUrl="/images/Uninstall.png",

                },
                new Other
                {
                    Title="Reinstall Auggie Client",
                    Info =new List<String>
                    {
                        "Reinstall the latest package","Using the same pakage we previosly used to uninstall, run the .exe without any arguments In PowerShell:"
                    },
                   ImageUrl= "/images/install.png",
                },
               new Other
               {
                   Title="startdownload.ps1 and networkconnect.ps1",
                   Info= new List<string>
                   {
                       "Update Scripts: Please copy and paste the following into both files.",
                       " Note: For privacy reasons, only a small portion will be shown.",

                   },
                   ImageUrl = "/images/Start.png "

               }

            };
            return View(otherpage);
        }

        public IActionResult Index()
        {
            return View();
        }


    }

}
