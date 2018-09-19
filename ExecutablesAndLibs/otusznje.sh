#!/bin/bash

add_bindings_data() {
    key1="org.gnome.settings-daemon.plugins.media-keys.custom-keybinding"
    key2="/org/gnome/settings-daemon/plugins/media-keys/custom-keybindings"

    gsettings set $key1":"$key2"/custom"$1"/" name "$2"
    gsettings set $key1":"$key2"/custom"$1"/" command "$3"
    gsettings set $key1":"$key2"/custom"$1"/" binding "$4"
}

add_bindings() {
    prefix="/org/gnome/settings-daemon/plugins/media-keys/custom-keybindings/custom"
    cmd1="["
    for i in $(seq 0 9)
    do
        cmd1=$cmd1"'"$prefix$i"/'"
        if [ $i -ne 9 ]
        then
            cmd1=$cmd1", "
        fi
    done
    cmd1=$cmd1"]"
    gsettings set org.gnome.settings-daemon.plugins.media-keys custom-keybindings "$cmd1"
}

progpath="/opt/MemeSoundboard/ExecutablesAndLibs/dzialaj.py"

add_bindings
add_bindings_data 0 "sound0" "python3 $progpath 0" "<Super><Alt>z"
add_bindings_data 1 "sound1" "python3 $progpath 1" "<Super><Alt>x"
add_bindings_data 2 "sound2" "python3 $progpath 2" "<Super><Alt>c"
add_bindings_data 3 "sound3" "python3 $progpath 3" "<Super><Alt>v"
add_bindings_data 4 "sound4" "python3 $progpath 4" "<Super><Alt>b"
add_bindings_data 5 "sound5" "python3 $progpath 5" "<Super><Alt>n"
add_bindings_data 6 "sound6" "python3 $progpath 6" "<Super><Alt>m"
add_bindings_data 7 "sound7" "python3 $progpath 7" "<Super><Alt>comma"
add_bindings_data 8 "sound8" "python3 $progpath 8" "<Super><Alt>period"
add_bindings_data 9 "sound9" "python3 $progpath 9" "<Super><Alt>slash"