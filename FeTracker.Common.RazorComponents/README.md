# FeTracker.Common.RazorComponents

This library has a dependency on FeTracker.Common.

To make use of the styles contained here, add a link to the stylesheet in your `index.html` to it, like:
```html
<link href="_content/FeTracker.Common.RazorComponents/fe-tracker-common.css" rel="stylesheet"/>
```

If you'd like to override styles, make sure to include that link _above_ the stylesheet(s) that would override any styles. For instance, if you want to emulate an EmoTracker layout with three rows of six columns, add your own `.tracker-grid` class in your `app.css` and update it as such:
```css
.tracker-grid {
    width: fit-content;
    grid-template-columns: repeat(6, 32px);
    grid-template-rows: repeat(3, 32px);
    grid-template-areas:
        "Crystal    Pass            Hook        DarknessCrystal     EarthCrystal    TwinHarp"
        "SandRuby   Package         BaronKey    MagmaKey            TowerKey        LucaKey"
        "Adamant    LegendSword     Pan         Spoon               RatTail         PinkTail";
    background-color: darkblue;
}
```