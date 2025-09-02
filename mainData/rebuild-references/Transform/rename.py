# bro 😭

import os

def rename(input_path:str) -> None:
    
    for dir_name in os.listdir(input_path):
        dir_path = os.path.join(input_path, dir_name)
            
        for file_name in os.listdir(dir_path):
            file_path = os.path.join(dir_path, file_name)
            
            new_file_path = file_path.replace(".txt", "")
            os.rename(file_path, new_file_path)
            


input_path = r"C:\Users\feist\Desktop\Nova pasta\epb-extracted\mainData\rebuild-references\Transform\json"

rename(input_path)