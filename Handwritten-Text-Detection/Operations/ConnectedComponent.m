function[output] = ConnectedComponent(img)
    rimg = ~img;
    rimg = imerode(rimg,strel('square',2));
    imshow(rimg);
    CC = bwconncomp(rimg,8);
    CCC = regionprops(CC,'centroid');
    CCCC = regionprops(CC, 'Area');
    output = zeros(CC.NumObjects, 3);
    
    for i = 1:CC.NumObjects
        output(i,1)= CCC(i).Centroid(1);
        output(i,2)= CCC(i).Centroid(2);
        output(i,3)= CCCC(i).Area;
    end
end