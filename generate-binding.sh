## create temp folder
mkdir shapie-afnetworking
cd shapie-afnetworking

## do binding
sharpie pod init iphoneos AFNetworking
sharpie pod binding -n AFNetworking

## copy assets
cp -p ./Binding/ ../binding