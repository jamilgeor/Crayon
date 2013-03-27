# Crayon
## CSS for Mobile Development

### Introduction
An open source CSS implementation for Xamarin mobile development tools

### Target Platforms
* Monotouch
* Mono for Android (Coming soon)

### Disclaimer
This is still in very early development stage. Would love feedback, contributions etc.

### Sample

CSS

```
* {
	font-size: 18px;
	font-family: GillSans;
}

#sample-button { 
    	height: 55px;
	width: 200px;
	opacity: 0.5;
	top: 50px;
	left: 75px;
	color: #FFFFFF;
	border-radius: 4px;
	border-width: 2px;
	border-color: #000000;
	background-color: #FF0000;
}

.sample-background {
	background-image: url('background.jpg');
	border-color: #DDDDDD;
	border-width: 5px;
}
```

C#

```
using Crayon;
using Crayon.MT;

...

var styleContext = new StyleContext (new IOSDeviceContext ());
styleContext.LoadStyleSheet ("style.css");

var button = UIButton.FromType (UIButtonType.Custom);
button.SetStyleId ("sample-button");

var background = new UIView();
background.SetStyleClass ("sample-background");

background.AddSubview(button);

```
Output

![image](https://raw.github.com/jamilgeor/Crayon/master/Images/readme_sample_1.png)

### Documentation
[IOS Documentation](https://github.com/jamilgeor/Crayon/wiki/ios-control-styling)

### Credits
* This project makes extensive use of [ExCSS](https://github.com/TylerBrinks/ExCSS)

### Contact
Twitter - [@jamilgeor](https://twitter.com/jamilgeor)
