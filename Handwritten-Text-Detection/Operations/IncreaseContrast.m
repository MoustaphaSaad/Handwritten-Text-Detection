function[result] = IncreaseContrast(img)
    result = imadjust(rgb2gray(img));
    imshow(result);
end