using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GymPlanner
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        /// 

        public string exercise1 { get; set; }
        public string exercise2 { get; set; }

        public string muscleExer1 { get; set; }
        public string muscleExer2 { get; set; }
        public string muscleExer3 { get; set; }
        public string muscleExer4 { get; set; }
        public string muscleExer5 { get; set; }
        public string muscleExer6 { get; set; }

        public int pagePath { get; set; }

        public string[,] GlobalExerciseArray = new string[43, 5] {
                {"Legs", "Barbell Full Squat", "ms-appx:///Assets/fullSquat.png", "Stand with your feet slightly wider than your hips.\n Your toes should be pointed slightly outward.\n Look straight ahead and stare at a spot on the wall.\n Bend knees to 90' while back is straight.", "https://www.youtube.com/watch?v=1xMaFs0L3ao" },
                {"Legs", "Barbell Lunge", "ms-appx:///Assets/lunges.png", "Keep your upper body straight\n Shoulders back and relaxed and chin up\n Always engage your core. \n Step forward with one leg\n Lower hips until both knees are bent at about a 90'", "https://www.youtube.com/watch?v=0_9sJd9P8M0" },
                {"Legs", "Barbell ATG Squat", "ms-appx:///Assets/atg.jpg", "Stand with your feet slightly wider than your hips.\n Your toes should be pointed slightly outward.\n Look straight ahead and stare at a spot on the wall.\n Bend knees past 90' while back is straight.", "https://www.youtube.com/watch?v=XLpIGd4ooso" },
                {"Legs", "Quad Extension on Machine", "ms-appx:///Assets/quadExtension.png", "Keep Feet pointed forward.\n Using your quads, extend your legs to their max. \n Slowly lower your legs", "https://www.youtube.com/watch?v=YyvSfVjQeL0" },
                {"Legs", "Leg Press", "ms-appx:///Assets/legPress.png", "Torse and legs should make 90' angle. \n Lower platform until lower/upper legs are 90'", "https://www.youtube.com/watch?v=IZxyjW7MPJQ" },
                {"Legs", "Barbell Deadlift", "ms-appx:///Assets/deadlift.png", "Center bar over feet. \n Bend at hip to grip bar. \n Lower hips, look forward. \n Take deep breath, lift through heels.", "https://www.youtube.com/watch?v=7Q_GnXm7LbI" },
                {"Legs", "Lying Leg Curls", "ms-appx:///Assets/hamstringCurls.png", "Adjust machine lever to fit height. \n Lie down, machine pads resting below calves. \n Make sure you are fully stretched.", "https://www.youtube.com/watch?v=1Tq3QdYUuHs" },
                {"Legs", "Standing Barbell Calf Raises", "ms-appx:///Assets/calfRaises.png", "Lift as high as you can onto your toes. \n Slowly lower heel back to floor.", "https://www.youtube.com/watch?v=3UWi44yN-wM" },
                {"Legs", "Glute Ham Raise", "ms-appx:///Assets/gluteRaises.jpg", "Adjust equipment to body. \n Place feet against footplate. \n Start from bottom of movement with arched back.", "https://www.youtube.com/watch?v=lZbONXtf07g&t=212s" },

                {"Chest", "Barbell Bench Press", "ms-appx:///Assets/barbellBench.png", "Lie down on bench. \n Arch back slightly. \n Push glutes towards you. \n Plant feet on ground for support.", "https://www.youtube.com/watch?v=rT7DgCr-3pg" },
                {"Chest", "Dumbell Bench Press", "ms-appx:///Assets/dumbellBench.png", "Lie down on bench. \n Arch back slightly. \n Push glutes towards you. \n Plant feet on ground for support.", "https://www.youtube.com/watch?v=VmB1G1K7v94&t=48s" },
                {"Chest", "Cable Cross Over", "ms-appx:///Assets/cableCrossOver.png", "Requires side-by-side cable machines. \n Preferably 2 hand grip attachments. \n Start with arms out wide. \n Pull diagonally down infront of you towards feet.", "https://www.youtube.com/watch?v=taI4XduLpTk" },
                {"Chest", "Incline Bench Press", "ms-appx:///Assets/inclineBarbellBench.png", "Adjust bench to 45'. Lie on bench. Grip bar past shoulder width. \n Slowly lower to chest and push upwards.", "https://www.youtube.com/watch?v=8iPEnn-ltC8" },
                {"Chest", "Dumbell Flyes", "ms-appx:///Assets/dumbellFlyes.png", "Adjust bench to 45'. \n Grab some dumbells, comfortable weight. \n Push arms straight up. \n Move arms away from eachother", "https://www.youtube.com/watch?v=eozdVDA78K0&t=67s" },
                {"Chest", "Pec Deck", "ms-appx:///Assets/pecDeck.png", "Find a pec deck machine. \n Adjust weight. \n Push arms together and hold at top", "https://www.youtube.com/watch?v=JJitfZKlKk4" },
                {"Chest", "Smith Machine Bench Press", "ms-appx:///Assets/flatSmith.png", "Find smith machine. \n Grab bar past shoulder width apart. \n Adjust weight if needed.", "https://www.youtube.com/watch?v=z_r6hDOYtO0" },
                {"Chest", "Smith Machine Incline Bench Press", "ms-appx:///Assets/url.jpg", "Adjust bench to 45'. \n Adjust weight. \n Grip past shoulder width.", "https://www.youtube.com/watch?v=b8DqTO6ak0k" },
                {"Chest", "Pull ups", "ms-appx:///Assets/pullUps.png", "Find a pull up bar. \n Grip the bar like you would for bench press. \n Pull upwards until head above bar.", "https://www.youtube.com/watch?v=eGo4IYlbE5g" },

                {"Shoulders", "Deltoid Raises", "ms-appx:///Assets/deltoidRaises.png", "Grab some dumbells. \n Lift one or both straight forward. \n Palms facing to the ground. \n Slow reps", "https://www.youtube.com/watch?v=-t7fuZ0KhDA" },
                {"Shoulders", "Overhead Barbell Press", "ms-appx:///Assets/overheadBarbell.png", "Find squat cage. \n Adjust arm height. \n Hold bar so knuckles nearly touching shoulders. \n Push up and slow down.", "https://www.youtube.com/watch?v=2yjwXTZQDDI" },
                {"Shoulders", "Overhead Dumbell Press", "ms-appx:///Assets/overheadDumbell.jpg", "Find dumbells. \n Either standing or sitting. \n Lift arms, elbows point away from chest. \n Push up and sowly down.", "https://www.youtube.com/watch?v=qEwKCR5JCog" },
                {"Shoulders", "Side Lateral Raises", "ms-appx:///Assets/shoulderFlies.png", "Get dumbells. \n Slowly raises both or one by your side. \n Palm facing down. \n Arm out to your sides.", "https://www.youtube.com/watch?v=3VcKaXpzqRo" },

                {"Triceps", "Dips", "ms-appx:///Assets/dips.png", "Find bars to do dips on. \n Grip bar like in picture. \n Slowly descend and elevate.", "https://www.youtube.com/watch?v=sM6XUdt1rm4" },
                {"Triceps", "Cable Tricep Extensions", "ms-appx:///Assets/tricepExtension.jpg", "Done on cable machine. \n Can be done with many attachments. \n Focus on tucking in elbows all the time.", "https://www.youtube.com/watch?v=2-LAMcpzODU" },
                {"Triceps", "Dumbell Skull Crushers", "ms-appx:///Assets/skull-dumbbell.png", "Done on bench. \n Arms same direction as body. \n Slowly descend forearms behind head.", "https://www.youtube.com/watch?v=ir5PsbniVSc" },
                {"Triceps", "Decline Dumbell Triceps Extensions", "ms-appx:///Assets/inclineTricepExtension.png", "Done on bench. \n Arms same direction as body. \n Slowly descend forearms behind head.", "https://www.youtube.com/watch?v=vLJX0UK07y4" },
                {"Triceps", "Tricep Dumbell KickBack", "ms-appx:///Assets/tricepKickback.png", "Find bench. \n Have one knee on bench. \n Have forearm, bicep 90'. \n Stretch Arm out, squeeze tricep.", "https://www.youtube.com/watch?v=6SS6K3lAwZ8" },
                {"Triceps", "Overhead Extension with Rope", "ms-appx:///Assets/overheadExtension.png", "Find cable machine with rope. \n Arms curled over your head gripping rope. \n Extend arm out, focus on tricep squeeze.", "https://www.youtube.com/watch?v=y1Vj_LhGjbA" },

                {"Biceps", "Chin Ups", "ms-appx:///Assets/chinUps.png", "Find bar, grip shoulder width. \n Palms facing towards your body. \n Lift yourself focusing on core and biceps.", "https://www.youtube.com/watch?v=bd_A0kDAyK4" },
                {"Biceps", "Dumbell Bicep Curls", "ms-appx:///Assets/dumbellCurls.png", "Hold dumbells like suitcases. \n Slowly turn palms towards you as lifting.", "https://www.youtube.com/watch?v=sAq_ocpRh_I" },
                {"Biceps", "Barbell Bicep Curls", "ms-appx:///Assets/barbellCurl.png", "Grip barbell shoulder width. \n Hold in front of hips. \n Palms facing away when fully stetched.", "https://www.youtube.com/watch?v=LY1V6UbRHFM" },
                {"Biceps", "Bicep Curls with Rope Attachment", "ms-appx:///Assets/bicepRopeCurls.jpg", "Exercise on cable machine. \n Grip rope, pull towards face. Don't move elbows.", "https://www.youtube.com/watch?v=Odz1T8WmDBI" },
                {"Biceps", "Bicep Curls with Curl Bar Attachment", "ms-appx:///Assets/cableCurl.png", "Exercise on cable machine. \n Grip bar, pull towards face. Don't move elbows.", "https://www.youtube.com/watch?v=AsAVbj7puKo" },
                {"Biceps", "Alternate Hammer Curls", "ms-appx:///Assets/hammerCurls.jpg", "Lift dumbells upwards. \n Don't move elbows if possible. \n Palms always facing center mass", "https://www.youtube.com/watch?v=zC3nLlEvin4" },

                {"Back", "Cable Lat Pulldown", "ms-appx:///Assets/latPulldown.png", "Find lat pulldown machine. \n Kepp back straight. \n Don't let shoulders collapse inwards. \n Pull towards chest", "https://www.youtube.com/watch?v=X5n55mMqSUs" },
                {"Back", "Cable rows", "ms-appx:///Assets/rowBack.png", "Find cable row machine. \n Pull row towards you. \n Kep elbows in close. \n Squeeze back", "https://www.youtube.com/watch?v=GZbfZ033f74" },
                {"Back", "Dumbell Incline Row", "ms-appx:///Assets/inclineRows.png", "Raise bench to 45'. \n Lie on bench. \n Lift dumbells, keep elbows close to sides", "https://www.youtube.com/watch?v=x6nEPnQ37FQ" },
                {"Back", "Back Extension", "ms-appx:///Assets/backExtension.png", "Find equipment. \n Start at legs to body 90'. \n Lift upper body until straight line then repeat.", "https://www.youtube.com/watch?v=ph3pddpKzzw" },

                {"Abs", "Knee Raises", "ms-appx:///Assets/kneeRaises.png", "Find pull up bar. \n Lift knees towards chest. \n Breath out as you start rep", "https://www.youtube.com/watch?v=BI7wrB3Crsc" },
                {"Abs", "Leg Raises", "ms-appx:///Assets/legRaises.jpg", "Find pull up bar. \n Lift legs straight out. \n Breath out as you start rep", "https://www.youtube.com/watch?v=ghwdoXHeiIk" },
                {"Abs", "Cable Crunches", "ms-appx:///Assets/cableCrunch.png", "Feel as if you push back towards ground. \n Pull your elbows to knees. \n Tense abs, breath out.", "https://www.youtube.com/watch?v=2fbujeH3F0E&t=98s" },
                {"Abs", "Oblique Floor Wipper", "ms-appx:///Assets/floorWipper.png", "Sweep legs from left to right. \n Focus on keeping back stationary. \n Keep breathing naturally.", "https://www.youtube.com/watch?v=WUU0MVoszJc" },
                {"Abs", "Ab Crunch Machine", "ms-appx:///Assets/abCrunch.png","Feel as if you push back towards ground. \n Pull your elbows to knees. \n Tense abs, breath out.", "https://www.youtube.com/watch?v=_O1xunCfYEM" },
        };

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
