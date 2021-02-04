/*
* Copyright (c) 2019 Samsung Electronics Co., Ltd.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*
*/

using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace HelloWorldTest
{
    class Example : NUIApplication
    {
        private Animation _animation;
        private int cnt;
        private View _view;
        TextField textField;
        TextField newTextField;
        public bool hidden;


        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        TextLabel pointLabel;
        public void Initialize()
        {
            hidden = true;
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            window.TouchEvent += OnWindowTouched;
            window.KeyEvent += OnWindowKeyEvent;
            window.Resized += (obj, e) =>
            {
                Tizen.Log.Fatal("NUI", "Height: " + e.WindowSize.Height);
                Tizen.Log.Fatal("NUI", "Width: " + e.WindowSize.Width);
            };
/*
            pointLabel = new TextLabel("Test Point Size 32.0f");
            pointLabel.Position2D = new Position2D(10, 70);
            pointLabel.Size2D = new Size2D(300, 150);

            pointLabel.PointSize = 30.0f;
            pointLabel.BackgroundColor = Color.Red;
            window.Add(pointLabel);
            pointLabel.Padding = new Extents(50, 50, 30, 30);
            pointLabel.Ellipsis = false;
            pointLabel.MultiLine = true;
/*
            Timer timer = new Timer(1000);

            Task.Factory.StartNew(() =>
            {
                try
                {
                    Timer timer_in_another_thread = new Timer(1000);

                    TextLabel ellipsis = new TextLabel("Ellipsis of TextLabel is enabled.");
                    ellipsis.Size2D = new Size2D(100, 100);
                    ellipsis.Position2D = new Position2D(10, 250);
                    ellipsis.PointSize = 20.0f;
                    ellipsis.Ellipsis = true;
                    window.Add(ellipsis);
                }
                catch (Exception e)
                {
                    Tizen.Log.Fatal("NUI", $"exception caught! e={e}");
                }
            }).Wait();
*/


/*
            textField = new TextField();
            textField.Text = "HELLO! this is wonrst test..!!";

            textField.PixelSize = 22;
            
            //HiddenInputModeType.HideAll;

            PropertyMap hiddenMap = new PropertyMap();
            hiddenMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.HideAll));

            //hiddenMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.ShowLastCharacter));
            //hiddenMap.Add(HiddenInputProperty.ShowLastCharacterDuration, new PropertyValue(1000));
            //hiddenMap.Add(HiddenInputProperty.SubstituteCount, new PropertyValue(4));
            //hiddenMap.Add(HiddenInputProperty.SubstituteCharacter, new PropertyValue("*"));
            //hiddenMap.Add(HiddenInputProperty.SubstituteCharacter, new PropertyValue(0x23));
            //textField.HiddenInputSettings = hiddenMap;

            //PropertyMap showMap = new PropertyMap();
            //showMap.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.HideNone));

            var pwdBtn = new Button();
            pwdBtn.Text = "o";
            //pwdBtn.ParentOrigin = ParentOrigin.CenterRight;
            //pwdBtn.PivotPoint = PivotPoint.CenterRight;
            //pwdBtn.PositionUsesPivotPoint = true;
            pwdBtn.Position2D = new Position2D(80, 0);
            pwdBtn.Size = new Size(50, 50);
            /*
            btn.ParentOrigin = ParentOrigin.CenterRight;
            btn.PivotPoint = PivotPoint.CenterRight;
            btn.PositionUsesPivotPoint = true;
            */

/*
            pwdBtn.Clicked += (sender, e) =>
            {
                textField.Padding = new Extents(20, 20, 5, 5);
                Tizen.Log.Fatal("NUI", "SIZE " + textField.Size2D.Width + " " + textField.Size2D.Height + " \n");
                if (hidden)
                {
                    //textField.HiddenInputSettings = showMap;
                    textField.Text = textField.Text;
                    hidden = false;
                }
                else
                {
                    //textField.HiddenInputSettings = hiddenMap;
                    textField.Text = textField.Text;
                    hidden = true;
                }
            };
            window.Add(pwdBtn);

            var clearBtn = new Button();
            clearBtn.Text = "x";
            //clearBtn.ParentOrigin = ParentOrigin.CenterRight;
            //clearBtn.PivotPoint = PivotPoint.CenterRight;
            //clearBtn.PositionUsesPivotPoint = true;
            clearBtn.Size = new Size(50, 50);
            clearBtn.Clicked += (sender, e) =>
            {
                textField.Text = "";

                textField.Padding = new Extents(50, 50, 0, 0);
                Tizen.Log.Fatal("NUI", "SIZE " + textField.Size2D.Width + " " + textField.Size2D.Height + " \n");

            };

            window.Add(clearBtn);

            textField.TextChanged += (sender, e) =>
            {
                Tizen.Log.Fatal("NUI", "TEXT CHANGED..!! \n");

                if (String.IsNullOrEmpty(textField.Text))
                {
                    clearBtn.Hide();
                }
                else
                {
                    clearBtn.Show();
                }
            };



            /*
            propertyMap.Add("placeholderText", new PropertyValue("TextField Placeholder Test"));
            propertyMap.Add("placeholderTextFocused", new PropertyValue("Placeholder Text Focused"));
            propertyMap.Add("placeholderColor", new PropertyValue(Color.Blue));
            propertyMap.Add("placeholderPointSize", new PropertyValue(20.0f));

            PropertyMap fontStyleMap = new PropertyMap();
            fontStyleMap.Add("weight", new PropertyValue("bold"));
            fontStyleMap.Add("width", new PropertyValue("condensed"));
            fontStyleMap.Add("slant", new PropertyValue("italic"));
            propertyMap.Add("placeholderFontStyle", new PropertyValue(fontStyleMap));
*/
/*
            textField.Size2D = new Size2D(300, 50);
            textField.Position2D = new Position2D(10, 230);
            textField.BackgroundColor = Color.Magenta;
            //textField.Placeholder = propertyMap;
            textField.Focusable = true;
            window.Add(textField);



            newTextField = new TextField();
//            newTextField.Text = "Key Subclass Test!";
            newTextField.Text = "&#x262a;&#xfe0f;";
            newTextField.Size2D = new Size2D(300, 50);
            newTextField.Position2D = new Position2D(10, 300);
            newTextField.BackgroundColor = Color.Cyan;
            newTextField.PointSize = 20;
            newTextField.Focusable = true;
            newTextField.EnableMarkup = true;

            //newTextField.EnableClearButton = true;
            //newTextField.EnablePasswordButton = true;


            newTextField.Padding = new Extents(100, 50, 0, 0);


            window.Add(newTextField);


            Tizen.Log.Fatal("NUI", "SIZE " + newTextField.Size2D.Width + " " + newTextField.Size2D.Height + " \n");



            //textField.Padding = new Extents(50, 50, 0, 0);

            //textField.InnerPadding = new Extents(20, 20, 0, 0);
            //textField.EnableInnerPadding = true;


            //WONRST
            //textField.EnableClearButton = true;
            //textField.EnablePasswordButton = true;



            //newTextField.Padding = new Extents(100, 50, 0, 0);


            var newBtn = new Button();
            newBtn.Text = "get size";
            newBtn.ParentOrigin = ParentOrigin.CenterRight;
            newBtn.PivotPoint = PivotPoint.CenterRight;
            newBtn.PositionUsesPivotPoint = true;
            newBtn.Size = new Size(100, 50);
            newBtn.Clicked += (sender, e) =>
            {
                textField.Padding = new Extents(100, 50, 5, 5);
                Tizen.Log.Fatal("NUI", "SIZE " + textField.Size2D.Width + " " + textField.Size2D.Height + " \n");

                Tizen.Log.Fatal("NUI", "LABEL SIZE " + pointLabel.Size2D.Width + " " + pointLabel.Size2D.Height + " \n");

                Tizen.Log.Fatal("NUI", "PAD " + textField.Padding.Start + " " + textField.Padding.End + " \n");
            };

            window.Add(newBtn);


            var newBtn2 = new Button();
            newBtn2.Text = "vis/invis";
            newBtn2.Position2D = new Position2D(50, 400);
            newBtn2.Size = new Size(100, 50);
            newBtn2.Clicked += (sender, e) =>
            {
                if (textField.EnableClearButton) textField.EnableClearButton = false;
                else textField.EnableClearButton = true;
            };

            window.Add(newBtn2);

            var newBtn3 = new Button();
            newBtn3.Text = "no pad";
            newBtn3.Position2D = new Position2D(50, 450);
            newBtn3.Size = new Size(100, 50);
            newBtn3.Clicked += (sender, e) =>
            {
                textField.Padding = new Extents(0, 0, 0, 0);
            };

            window.Add(newBtn3);


            var newBtn4 = new Button();
            newBtn4.Text = "eye";
            newBtn4.Position2D = new Position2D(50, 500);
            newBtn4.Size = new Size(100, 50);
            newBtn4.Clicked += (sender, e) =>
            {
                if (textField.EnablePasswordButton)
                {
                    textField.EnablePasswordButton = false;
                }
                else
                {
                    textField.EnablePasswordButton = true;
                }
            };

            window.Add(newBtn4);


            var newBtn5 = new Button();
            newBtn5.Text = "property";
            newBtn5.Position2D = new Position2D(50, 550);
            newBtn5.Size = new Size(100, 50);
            newBtn5.Clicked += (sender, e) =>
            {
                var map = new PropertyMap();
                map.Add(HiddenInputProperty.Mode, new PropertyValue((int)HiddenInputModeType.HideAll));
                textField.HiddenInputSettings = map;
                textField.Text = textField.Text;
            };

            window.Add(newBtn5);

/*
            var button = new Button();
            button.Text = "Hello";
            button.Size = new Size(120, 80);
 
            window.Add(button);
*/

            TextEditor myTextEditor;

            myTextEditor = new TextEditor();
            //myTextEditor.Position2D = new Position2D(10, 700);
            myTextEditor.Position2D = new Position2D(10, 1);
            myTextEditor.Size2D = new Size2D(400, 400);
            myTextEditor.BackgroundColor = Color.Red;
            myTextEditor.PointSize = 20;
            myTextEditor.TextColor = Color.White;
            //myTextEditor.MultiLine = true;
            myTextEditor.LineWrapMode = LineWrapMode.Character;
            myTextEditor.Text = $"[TextEditor LineWrapMode.Character] hello ABCDEFGHI is my name, it is very very long beautiful hansome awesome name.";
            Window.Instance.GetDefaultLayer().Add(myTextEditor);
            //myTextEditor.Padding = new Extents(100, 100, 20, 20);


            myTextEditor.TextChanged += (sender, e) =>
            {
                Tizen.Log.Fatal("NUI", "text editor CHANGED..!! \n");
            };


            Vector3 originalSize;

            var newBtn6 = new Button();
            newBtn6.Text = "natural";
            newBtn6.Position2D = new Position2D(50, 650);
            newBtn6.Size = new Size(100, 50);
            newBtn6.Clicked += (sender, e) =>
            {
                Tizen.Log.Fatal("NUI", "\n-------------------------NATURAL-----------------------------\n\n");

                originalSize = myTextEditor.GetNaturalSize();

                Tizen.Log.Fatal("NUI", "-------------Natural Size " + originalSize.X + " " + originalSize.Y + " " + originalSize.Z + "\n");
                
            };

            window.Add(newBtn6);


            var newBtn7 = new Button();
            newBtn7.Text = "natural";
            newBtn7.Position2D = new Position2D(150, 650);
            newBtn7.Size = new Size(100, 50);
            newBtn7.Clicked += (sender, e) =>
            {
                float height = myTextEditor.GetHeightForWidth( myTextEditor.Size.Width );

                Tizen.Log.Fatal("NUI", "GetHeightForWidth W " + myTextEditor.Size.Width + " H" + height + "\n");
                
            };

            window.Add(newBtn7);





            _view = new View();
            _view.Size2D = new Size2D(100, 100);
            _view.SizeWidth = 50;
            Tizen.Log.Fatal("NUI", "[1]_view SizeWidth=" + _view.SizeWidth);

            _animation = new Animation
            {
                Duration = 2000
            };
            _animation.EndAction = Animation.EndActions.Discard;
            _animation.Finished += AnimationFinished;

            _view.SizeWidth = 50;
            Tizen.Log.Fatal("NUI", "[2]_view SizeWidth=" + _view.SizeWidth);

            ViewLayoutDirectionTest();


        }







        private View view1, view11, view12, view111, view121;
        public void ViewLayoutDirectionTest()
        {
            view1 = new View();
            view1.Name = "view 1";
            view1.LayoutDirection = ViewLayoutDirectionType.RTL;
            Window.Instance.GetDefaultLayer().Add(view1);
            view1.LayoutDirectionChanged += View1_LayoutDirectionChanged;

            view11 = new View();
            view11.Name = "view 11";
            view11.InheritLayoutDirection = true;
            view1.Add(view11);

            view12 = new View();
            view12.Name = "view 12";
            view12.LayoutDirection = ViewLayoutDirectionType.LTR;
            view1.Add(view12);

            view111 = new View();
            view111.Name = "view 111";
            view111.InheritLayoutDirection = true;
            view11.Add(view111);

            view121 = new View();
            view121.Name = "view 121";
            view121.InheritLayoutDirection = true;
            view12.Add(view121);
        }

        private void View1_LayoutDirectionChanged(object sender, View.LayoutDirectionChangedEventArgs e)
        {
            Tizen.Log.Error("NUI", "View1_LayoutDirectionChanged()! e.Type=" + e.Type);
        }

        public void AnimationFinished(object sender, EventArgs e)
        {
            Tizen.Log.Fatal("NUI", "AnimationFinished()! cnt=" + (cnt));
            if (_animation)
            {
                Tizen.Log.Fatal("NUI", "Duration= " + _animation.Duration + "EndAction= " + _animation.EndAction);
            }
            _view.SizeWidth = 50;
            Tizen.Log.Fatal("NUI", "[3]_view SizeWidth=" + _view.SizeWidth);
        }

        int win_test;
        public void OnWindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            Tizen.Log.Fatal("NUI", "e.Key.KeyPressedName=" + e.Key.KeyPressedName);

            if (e.Key.State == Key.StateType.Down)
            {
                //keySubclassTest.Text = $"DeviceSubClass={e.Key.DeviceSubClass}, DeviceClass={e.Key.DeviceClass}, DeviceName={e.Key.DeviceName}, KeyCode={e.Key.KeyCode}";

                switch( e.Key.KeyPressedName )
                {
                    case "Up":
                    {
                        if (_animation)
                        {
                            _animation.Finished += AnimationFinished;
                            cnt++;
                            Tizen.Log.Fatal("NUI", "AnimationFinished added!");
                        }

                    }
                    break;

                    case "Down":
                    {
                        if (_animation)
                        {
                            _animation.Finished -= AnimationFinished;
                            cnt--;
                            Tizen.Log.Fatal("NUI", "AnimationFinished removed!");
                        }

                        Window.Instance.SetClass($"Window.SetClass() Test #{win_test++}", "");
                        Tizen.Log.Fatal("NUI", $"Check with enlightenment_info -topwins ! Window.SetClass() Test #{win_test}");
                    }
                    break;

                    case "Return":
                    {
                        _animation.Play();
                        Tizen.Log.Fatal("NUI", "_animation play here!");
                    }
                    break;

                    case "Escape":
                    case "Back":
                    {
                        Exit();
                    }
                    break;
                }
            }
        }

        public void OnWindowTouched(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                _animation.Play();
            }
        }

        private TextEditor myTextEditor;
        private TextEditor myTextEditor2;
        public void TextLabelLineWrapModeTest()
        {
            Tizen.Log.Fatal("NUI", "WrapModeTest START!");

            myTextEditor = new TextEditor();
            myTextEditor.Position2D = new Position2D(10, 700);
            myTextEditor.Size2D = new Size2D(400, 90);
            myTextEditor.BackgroundColor = Color.Red;
            myTextEditor.PointSize = 20;
            myTextEditor.TextColor = Color.White;
            //myTextEditor.MultiLine = true;
            myTextEditor.LineWrapMode = LineWrapMode.Character;
            myTextEditor.Text = $"[TextEditor LineWrapMode.Character] hello ABCDEFGHI is my name, it is very very long beautiful hansome awesome name.";
            Window.Instance.GetDefaultLayer().Add(myTextEditor);
            myTextEditor.Padding = new Extents(100, 100, 20, 20);

            myTextEditor2 = new TextEditor();
            myTextEditor2.Position2D = new Position2D(450, 700);
            myTextEditor2.Size2D = new Size2D(400, 90);
            myTextEditor2.BackgroundColor = Color.Red;
            myTextEditor2.PointSize = 20;
            myTextEditor2.TextColor = Color.White;
            //myTextEditor2.MultiLine = true;
            myTextEditor2.LineWrapMode = LineWrapMode.Word;
            myTextEditor2.Text = $"[TextEditor LineWrapMode.Word] hello ABCDEFGHI is my name, it is very very long beautiful hansome awesome name.";
            Window.Instance.GetDefaultLayer().Add(myTextEditor2);

            Tizen.Log.Fatal("NUI", $"TextEditor LineWrapMode 1st={ myTextEditor?.LineWrapMode} 2nd={ myTextEditor2?.LineWrapMode}");
        }

        [STAThread]
        static void Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
