siwameron@MyComputer:~$ /home/siwameron/vcpkg/vcpkg install openimageio
Computing installation plan...
The following packages will be built and installed:
    openimageio:x64-linux@2.4.14.0#3
  * tiff[core,jpeg,lzma,zip]:x64-linux@4.6.0#2
Additional packages (*) will be modified to complete this operation.
Detecting compiler hash for triplet x64-linux...
Restored 0 package(s) from /home/siwameron/.cache/vcpkg/archives in 4.97 us. Use --debug to see more details.
Installing 1/2 tiff[core,jpeg,lzma,zip]:x64-linux@4.6.0#2...
Building tiff[core,jpeg,lzma,zip]:x64-linux@4.6.0#2...
-- Using cached libtiff-libtiff-v4.6.0.tar.gz.
-- Cleaning sources at /home/siwameron/vcpkg/buildtrees/tiff/src/v4.6.0-ba2cf5b685.clean. Use --editable to skip cleaning for the packages you specify.
-- Extracting source /home/siwameron/vcpkg/downloads/libtiff-libtiff-v4.6.0.tar.gz
-- Applying patch FindCMath.patch
-- Using source at /home/siwameron/vcpkg/buildtrees/tiff/src/v4.6.0-ba2cf5b685.clean
-- Configuring x64-linux
CMake Error at scripts/cmake/vcpkg_execute_required_process.cmake:112 (message):
    Command failed: /home/siwameron/vcpkg/downloads/tools/ninja/1.10.2-linux/ninja -v
    Working Directory: /home/siwameron/vcpkg/buildtrees/tiff/x64-linux-rel/vcpkg-parallel-configure
    Error code: 1
    See logs for more information:
      /home/siwameron/vcpkg/buildtrees/tiff/config-x64-linux-dbg-CMakeCache.txt.log
      /home/siwameron/vcpkg/buildtrees/tiff/config-x64-linux-rel-CMakeCache.txt.log
      /home/siwameron/vcpkg/buildtrees/tiff/config-x64-linux-out.log

Call Stack (most recent call first):
  installed/x64-linux/share/vcpkg-cmake/vcpkg_cmake_configure.cmake:252 (vcpkg_execute_required_process)
  ports/tiff/portfile.cmake:30 (vcpkg_cmake_configure)
  scripts/ports.cmake:170 (include)


error: building tiff:x64-linux failed with: BUILD_FAILED
Elapsed time to handle tiff:x64-linux: 24 s
Please ensure you're using the latest port files with `git pull` and `vcpkg update`.
Then check for known issues at:
  https://github.com/microsoft/vcpkg/issues?q=is%3Aissue+is%3Aopen+in%3Atitle+tiff
You can submit a new issue at:
  https://github.com/microsoft/vcpkg/issues/new?title=[tiff]+Build+error+on+x64-linux&body=Copy+issue+body+from+%2Fhome%2Fsiwameron%2Fvcpkg%2Finstalled%2Fvcpkg%2Fissue_body.md
