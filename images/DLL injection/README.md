# DLL injection Code Injection

```cs
using (System.Diagnostics.Process process = new System.Diagnostics.Process())
{
  process.StartInfo.FileName = path;
  process.Start();
  process.WaitForExit();
}
```

Hvis path bliver ændret via command injection kan vi ændre kommandien den kører:

```cs
string path = "notepad.exe && shutdown -s";
```
