NDSummary.OnToolTipsLoaded("File:HexMapEditor.cs",{16:"<div class=\"NDToolTip TClass LCSharp\"><div class=\"NDClassPrototype\" id=\"NDClassPrototype16\"><div class=\"CPEntry TClass Current\"><div class=\"CPModifiers\"><span class=\"SHKeyword\">public</span></div><div class=\"CPName\">HexMapEditor</div></div></div><div class=\"TTSummary\">This class is the de facto UI class of the project at this point It contains the UI canvas, as well as the functionality for the map editor and progressing the turn.</div></div>",18:"<div class=\"NDToolTip TVariable LCSharp\"><div id=\"NDPrototype18\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">public</span> Color[] colors</div><div class=\"TTSummary\">This array contains all the possible colors we can use for coloring hexes.</div></div>",19:"<div class=\"NDToolTip TVariable LCSharp\"><div id=\"NDPrototype19\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">public</span> HexGrid hexGrid</div><div class=\"TTSummary\">A reference to the grid.</div></div>",20:"<div class=\"NDToolTip TVariable LCSharp\"><div id=\"NDPrototype20\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">public</span> HexUnit unitPrefab</div><div class=\"TTSummary\">A reference to the prefab of the generic unit game object</div></div>",21:"<div class=\"NDToolTip TVariable LCSharp\"><div id=\"NDPrototype21\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">private</span> Color activeColor</div></div>",22:"<div class=\"NDToolTip TVariable LCSharp\"><div id=\"NDPrototype22\" class=\"NDPrototype NoParameterForm\">HexCell currentCell</div></div>",24:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype24\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">private void</span> Awake()</div></div>",25:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype25\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">private void</span> Update()</div></div>",26:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype26\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">void</span> HandleInput()</div></div>",27:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype27\" class=\"NDPrototype NoParameterForm\">HexCell GetCellUnderCursor()</div></div>",28:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype28\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">void</span> CreateUnit ()</div></div>",29:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype29\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">void</span> DestroyUnit()</div></div>",31:"<div class=\"NDToolTip TVariable LCSharp\"><div id=\"NDPrototype31\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">bool</span> applyColor</div></div>",33:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype33\" class=\"NDPrototype WideForm CStyle\"><table><tr><td class=\"PBeforeParameters\"><span class=\"SHKeyword\">void</span> EditCell (</td><td class=\"PParametersParentCell\"><table class=\"PParameters\"><tr><td class=\"PType first\">HexCell&nbsp;</td><td class=\"PName last\">cell</td></tr></table></td><td class=\"PAfterParameters\">)</td></tr></table></div></div>",34:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype34\" class=\"NDPrototype WideForm CStyle\"><table><tr><td class=\"PBeforeParameters\"><span class=\"SHKeyword\">public void</span> SelectColor (</td><td class=\"PParametersParentCell\"><table class=\"PParameters\"><tr><td class=\"PType first\"><span class=\"SHKeyword\">int</span>&nbsp;</td><td class=\"PName last\">index</td></tr></table></td><td class=\"PAfterParameters\">)</td></tr></table></div></div>",36:"<div class=\"NDToolTip TVariable LCSharp\"><div id=\"NDPrototype36\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">bool</span> buildTown</div></div>",38:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype38\" class=\"NDPrototype WideForm CStyle\"><table><tr><td class=\"PBeforeParameters\"><span class=\"SHKeyword\">public void</span> SetBuildTown(</td><td class=\"PParametersParentCell\"><table class=\"PParameters\"><tr><td class=\"PType first\"><span class=\"SHKeyword\">bool</span>&nbsp;</td><td class=\"PName last\">toggle</td></tr></table></td><td class=\"PAfterParameters\">)</td></tr></table></div></div>",39:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype39\" class=\"NDPrototype WideForm CStyle\"><table><tr><td class=\"PBeforeParameters\"><span class=\"SHKeyword\">public void</span> SetEditMode (</td><td class=\"PParametersParentCell\"><table class=\"PParameters\"><tr><td class=\"PType first\"><span class=\"SHKeyword\">bool</span>&nbsp;</td><td class=\"PName last\">toggle</td></tr></table></td><td class=\"PAfterParameters\">)</td></tr></table></div><div class=\"TTSummary\">This toggle turns editing mode on or off. It is currently not connected to the toggle button on the scene.</div></div>",40:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype40\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">bool</span> UpdateCurrentCell()</div></div>",41:"<div class=\"NDToolTip TFunction LCSharp\"><div id=\"NDPrototype41\" class=\"NDPrototype NoParameterForm\"><span class=\"SHKeyword\">public void</span> AdvanceTurn()</div><div class=\"TTSummary\">This method runs the simulation logic for one cycle. Currently this logic only contains a random move for all existing units.</div></div>"});