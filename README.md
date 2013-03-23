# Crayon
## CSS for Mobile Development

### Introduction
An open source CSS implementation for Xamarin mobile development tools

### Target Platforms
* Monotouch
* Mono for Android (Coming soon)


### Samples

CSS

```
#my-button { top: 50px; left: 100px; }
```

C#

```
using Crayon;
using Crayon.MT;

...

var styleContext = new StyleContext (new IOSDeviceContext ());
styleContext.LoadStyleSheet ("style.css");

var button = new UIButton();
button.SetStyleId("my-button");

```

### Documentation
[IOS Documentation](https://github.com/jamilgeor/Crayon/wiki/ios-control-progress)