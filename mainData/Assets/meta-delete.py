import os

def delete_meta_files(path:str) -> None:
    for folder in os.listdir(path):
        if len(folder.split(".")) == 1:
            asset_folder = os.path.join(path, folder)
            for file in os.listdir(asset_folder):
                if file.endswith(".meta"):
                    file_path = os.path.join(asset_folder, file)
                    #print(file_path)
                    os.remove(file_path)    

if __name__ == "__main__":
    delete_meta_files(os.getcwd())