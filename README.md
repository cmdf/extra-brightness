Get or set screen brightness from Windows Console.
> 1. Download [exe file](https://raw.githubusercontent.com/winp/extra-bel/master/ecd.cmd).
> 2. Copy to `C:\Program_Files\Scripts`.
> 3. Add `C:\Program_Files\Scripts` to `PATH` environment variable.


```batch
> ebrightness [<value>]

:: [] -> optional argument
:: <> -> argument value
```

```batch
:: get screen brightness
> ebrightness

:: set screen brightness to 50%
> ebrightness 50
```
