find . -type f -name "*.suo" -delete -print
find . -type f -name "*.vssscc" -delete -print
find . -type f -name "*.mpack" -delete -print
find . -type d -name "obj" -exec rm -rf {} + -print
find . -type d -name "bin" -exec rm -rf {} + -print

rm -rf ./.vs/
rm -rf ./Build/
rm -rf ./DTAR_08E86330_4835_4B5C_9E5A_61F37AE1A077_DTAR/

