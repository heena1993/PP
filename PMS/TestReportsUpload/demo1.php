<!DOCTYPE html>
<html>
<head>
<style> 
div {
    width: 100px;
    height: 100px;
    background: red;
    position: relative;
    -webkit-animation: mymove 5s infinite; /* Safari 4.0 - 8.0 */
    animation: mymove 5s infinite;
}

/* Safari 4.0 - 8.0 */
@-webkit-keyframes mymove {
    from {left: 0px;}
    to {left: 200px;}
}

@keyframes mymove {
    from {left: 0px;}
    to {left: 200px;}
}
</style>
</head>
<body>

<p>Make an element go from 0px to 200px from the left. The animation should take 5 seconds and it should go on forever (infinitely).</p>
<div></div>
<p><strong>Note:</strong> The animation property is not supported in Internet Explorer 9 and earlier versions.</p>

</body>
</html>