using Microsoft.AspNetCore.Mvc;
using Auggie_IT_Support_Portal.Models;
using Auggie_IT_Support_Portal.Models.ViewModels;
using System.Linq;
/*using Microsoft.AspNetCore.Mvc;
using Auggie_IT_Support_Portal.Models;
using Auggie_IT_Support_Portal.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using Auggie_IT_Support_Portal.ViewModels;
using System.Reflection;*/

namespace Auggie_IT_Support_Portal.Controllers
{
    public class LinuxSupportController : Controller
    {
        public IActionResult LinuxSoftware()
        {
            var model = new List<LinuxSoftware>
            {
                new LinuxSoftware
                {
                    Title = "Install Software",
                    Description = "Remote into the device with TeamViewer or SSH. Transfer the Debian Package (.deb) to the Auggie. " +
                                  "TeamViewer: File transfer. SSH.",
                    ImageUrl = "/images/InstallAuggieL.png",
                    Desc = "Although the software should already be installed, additional configuration is required before it can be used. " +
                           "Please ensure the following components are properly configured:",
                    subdes = new List<string>
                    {
                        "Displays", "GNOME Tweaks", "TeamViewer", "Orien", "PROD environment", "UAT environment"
                    }
                },
                new LinuxSoftware
                {
                    Title = "Error Updating Auggie Software",
                    Description = "If you're having trouble updating the software, try opening the terminal and running the following commands:",
                    ImageUrl = "/images/ErrorL.png",
                    Desc = "Make sure 'APT::Periodic::Unattended-Update' is set to '0'.",
                    subdes = new List<string>{

                            "Save changes to the file: CTRL+S",
                            "Exit: CTRL+X",
                            "Run: sudo reboot"
                    }
                }
            };

            return View(model);
        }


        public IActionResult Camera()
        {
            var model = new List<Camera>
            {
                new Camera
                {
                    Title="Analyze attached USB devices",
                    ImageUrl= "/images/cameraL.png",
                    Description="If no camera device appears in the list, there may be a hardware issue with your device."
                },
                new Camera
                {
                    Title ="Look at hardware logs",
                    ImageUrl = "/images/dmesg.png",
                    Description ="Take notice of the dmesg re-lated logs:"
                },
                new Camera
                {
                    Title = "Identify files associated with hardware",
                    ImageUrl="/images/devL.png",
                    Description="On Linux systems, webcams are represented by device files under /dev, such as /dev/video0. If your camera is correctly detected, you should see a file like /dev/video0. " +
                    "If not, the system isn't recognizing the camera as a video device"
                }
            };
            return View(model);
        }




        public IActionResult wifiL()
        {
            var model = new wifiL
            {
                Title = "Wifi Disable Gudie",
                Description = "LattePanda 2 devices use a different method to disable onboard Wi-Fi," +
                " which can cause conflicts when two network adapters have similar MAC addresses. " +
                "This may lead to issues with serial number recognition in Auggie management.\r\n",
                ImageUrl = new List<string>
                {
                    "/images/wifiL1.png",
                    "/images/wifiL2.png",
                    "/images/wifil3.png",
                    "/images/wifil4.png"
                }


            };




            return View(model);
        }





        public IActionResult Boot()
        {
            var bootsteps = new List<Boot>
            {
                new Boot
                {
                    Title ="Device Boots to BIOS Instead of Operating System",
                    Description="If the system boots to the logo and then immediately enters the BIOS, it usually indicates a problem with the boot order—specifically, that the operating system isn’t being detected, so the system defaults to the BIOS. We've found that in these cases, the eMMC storage used for Ubuntu is often recognized simply as a “Hard Drive.” To resolve this, go into the BIOS and switch the boot mode from UEFI to Legacy, save the changes, and reboot. " +
                    "Then, go back into the BIOS, switch the mode back to UEFI, save again, and reboot. After this process, the hard drive is typically recognized correctly.\r\n"
                },
                new Boot
                {
                    Title = "Troubleshooting: Device Boots to BIOS",
                    Description="First, power cycle the device and attempt to boot again. " +
                    "If the issue persists, reimaging the device may be required to resolve the problem.\r\n"
                }
            };

            var boottwo = new List<BootAdvcs>
            {
                new BootAdvcs
                {
                    Title = "GRUB (Bootloader) Issue:",
                    Description = "Restart the device by performing a power cycle, then try again." +
                    " Occasionally, you may see a 60-second countdown on this screen—simply allow it to finish, " +
                    "as the device may boot normally afterward. " +
                    "If the issue persists after the countdown or power cycle, the device will need to be reimaged.\r\n",
                    ImageUrl = "/images/grub.png"


                },
                new BootAdvcs
                {
                    Title = "Kernel Panic / System Halted",
                    Description = "This typically occurs due to critical system errors or hardware compatibility issues." +
                    " Try resolving the issue by performing a power cycle (fully shutting down and restarting the device). " +
                    "If the problem persists, the device will need to be reimaged.\r\n",
                    ImageUrl = "/images/kernel.png"
                }


            };
            var viewModel = new Bootup
            {
                Boots = bootsteps,
                BootAdvcs = boottwo
            };

            return View(viewModel);


        }



        public IActionResult Index()
        {
            return View();



        }
    }
}