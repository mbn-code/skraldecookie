# skraldecookie

# Hvorfor er det skrald?
Overvej at være et kommercielt firma der udvikler et program til at undgå eksamenssnyd, og så obfuskerer man ikke engang sin .net code. Det satme godt gået, dnSpy all the way

# Mulige Attack Vectors

### Screenshots
Der gøres brug af [System.Drawing.Graphics.CopyFromScreen](https://github.com/dotnet/winforms/blob/62ebdb4b0d5cc7e163b8dc9331dc196e576bf162/src/System.Drawing.Common/src/System/Drawing/Graphics.cs#L2691), som i .NET kalder [BitBlt](https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-bitblt) for at tage et billede af skærmen.
Dette er relativt nemt at komme udenom, en simpel BitBlt Hook ville kunne fjerne den eller de vinduer man har lyst til at gemme:

```cpp
BOOL __stdcall hooks::bit_blt(HDC hdc, int x, int y, int cx, int cy, HDC hdc_src, int x1, int y1, DWORD rop)
{
	const auto window_handle = FindWindowA("Notepad", nullptr);
	ShowWindow(window_handle, SW_HIDE);

	auto result = hooks::original_bit_blt(hdc, x, y, cx, cy, hdc_src, x1, y1, rop);

	ShowWindow(window_handle, SW_SHOW);

	return result;
}
```
I ovenstående eksempel gemmes `Notepad` vinduet, men det kan nemt ændres, og et simpelt system der kan læse en liste ville kunne gemme alle vinduer man har lyst til.

### Clipboard
Der gøres brug af [System.Windows.Forms.Clipboard](https://github.com/dotnet/winforms/blob/62ebdb4b0d5cc7e163b8dc9331dc196e576bf162/src/System.Windows.Forms/src/System/Windows/Forms/OLE/Clipboard.cs#L79), som I .NET kalder [OleGetClipboard](https://learn.microsoft.com/en-us/windows/win32/api/ole2/nf-ole2-olegetclipboard) for at finde ud af hvad man har i sit clipboard.
Dette er endnu nemmere at komme udenom, endnu en simpel hook og så bare returner en `S_OK` uden at update *ppDataObj

```cpp
BOOL __stdcall hooks::ole_get_clipboard(void* ppDataObj)
{
	return S_OK;
}
```

### Hjemmeside URL's
Der gøres brug af en større funktion kaldet [GetBrowserURL](https://github.com/mbn-code/skraldecookie/blob/main/ExamCookie1414_Dump/ExamCookie/WinClient/ApplicationThread.cs#L180) som først checker hvilken browser man bruger, og det er er så ikke en specielt god implementation.

For det første checkes der en liste med processnavne, og hvis den ikke kan finde en den kender, så returnerer den bare uden at checke URL'en:
```cs
if (!((IEnumerable<string>) new string[6]
{
    "iexplore",
    "chrome",
    "brave",
    "firefox",
    "msedge",
    "opera"
}).Contains<string>(name.ToLower()))
{
    result = "Ukendt browser";
    browserUrl = 1;
}
else
{
    //...
}
```

Det er hurigt at se, et simpelt fix ville være at bruge en browser der ikke er i listen, som f.eks Tor.
Eller ændre processnavnet på ens browser.

Hvis du deridmod bruger en af browserne, går koden videre og prøver at finde browserens URL. Den gør brug af `CUIAutomation` til at navigere og kigge i browserens elementer.
Den prøver så at finde det rigtige element i browseren baseret på hardcodet elementer:
Internet Explorer: Property `Edit`
Chrome/Brave: Property `Ctrl+L`
Firefox: Property `Gecko`
Edge: Property `OmniboxViewViews`
Opera: Property `Adressefelt` eller `Address field`

En måde at komme udenom dette kunne være f.eks. at bruge `Fiddler` til at replace URL'en i browseren. Følgende ville kunne virke:

```cs
private static void FiddlerApplication_BeforeRequest(Session oSession)
{
    if (oSession.fullUrl.Contains("xxx.com"))
    {
        oSession.fullUrl = oSession.fullUrl.Replace("xxx.com", "google.com");
    }
}
```