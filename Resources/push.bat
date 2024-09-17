adb connect 127.0.0.1:5555
adb connect 127.0.0.1:16384
adb -s emulator-5554 push "C:\ver.xml" "/storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/ver.xml"
adb -s 127.0.0.1:5555 push "C:\ver.xml" "/storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/ver.xml"
adb -s 127.0.0.1:16384 push "C:\ver.xml" "/storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/ver.xml"
Exit