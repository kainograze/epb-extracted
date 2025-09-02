# 100% ignoring how lazy i am to deal with jsons in c# to write this directly in tiny ripper

import os, json

def open_txt(path:str) -> str:
    with open(path, "r", encoding="utf-8") as file:
        return file.read()

def convert_to_dict(txt:str) -> dict:
    # split by line, then save each line as a json key
    
    dictionary: dict = {}
    
    for line in txt.split("\n"):
        k, d = line.split(": ")
        
        if d.startswith("["):
            replace_items = ["[","]"," "]
            for i in replace_items:
                d = d.replace(i, "")
            
            d_array = [float(i) for i in d.split(",")]
            dictionary[k] = d_array
        
        else:
            dictionary[k] = d
            
    return dictionary

def dump_json(dictionary:dict, path:str) -> None:
    with open(path, "w") as file:
        json.dump(dictionary, file, indent=4)
        
def get_json_output_path(path:str, dir:str, file_name:str) -> str:
    dir_path = os.path.join(path, dir)
    if not os.path.isdir(dir_path):
        os.mkdir(dir_path)
    
    json_path = os.path.join(dir_path,file_name+".json")
    return json_path

def convert_to_json(input_path:str,output_path:str) -> None:
    # loop to convert to json
    
    for dir_name in os.listdir(input_path):
        dir_path = os.path.join(input_path, dir_name)
            
        for file_name in os.listdir(dir_path):
            file_path = os.path.join(dir_path, file_name)
            
            txt_content = open_txt(file_path)
            json_dict = convert_to_dict(txt_content)
            
            json_output_path = get_json_output_path(output_path, dir_name, file_name)
            
            dump_json(json_dict, json_output_path)

input_path = r"C:\Users\feist\Desktop\Nova pasta\epb-extracted\mainData\Assets\Transform\txt"
output_path = r"C:\Users\feist\Desktop\Nova pasta\epb-extracted\mainData\Assets\Transform\json"

convert_to_json(input_path, output_path)