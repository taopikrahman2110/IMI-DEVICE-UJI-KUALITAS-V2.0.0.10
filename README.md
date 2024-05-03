# Before Running the App
Make sure to install Gemalto passport scanner driver first (Driver ver 3.7.1.16).<br/>
Change solution working folder to installation folder: C:\Program Files (x86)\Thales\Gemalto Document Reader SDK\3.7.1.16\Bin\ (Windows 64 bit) or C:\Program Files\Thales\Gemalto Document Reader SDK\3.7.1.16\Bin\ (Windows 32 bit)<br/>
working folder can be found in project property window -> Debug -> working folder. <br/>
if running the exe, copy the exe into installation folder: C:\Program Files (x86)\Thales\Gemalto Document Reader SDK\3.7.1.16\Bin\ (Windows 64 bit) or C:\Program Files\Thales\Gemalto Document Reader SDK\3.7.1.16\Bin\ (Windows 32 bit)

## Warning
Run from Visual Studio using Debug/Release x86 configuration!.

## PS
App has been tested using following device: <br/>
- 3M Passport Scanner series (AT9000).
- Gemalto Passport Scanner series (AT9000).
- Gemalto Passport Scanner series (AT10000).

##
1. INSTALL DRIVER & SDK GEMALTO 3.7.1.17
2. BUILD dengan Release x86
3. AFTER BUILD => Copy File2 Berikut ke	C:\Program Files (x86)\Thales\Gemalto Document Reader SDK\3.7.1.17\Bin\
	- MRZReader.exe
	- MRZReader.exe.config
4. Untuk Debug Set Working Directory:
	C:\Program Files (x86)\Thales\Gemalto Document Reader SDK\3.7.1.17\Bin
   Dan command line arguments:
	Ambil dr generate payload aplikasi alur pencetakan
