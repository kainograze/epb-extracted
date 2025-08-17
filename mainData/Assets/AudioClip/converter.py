# basic raw audio asset parser
import os, sys, struct, pydub
from io import BytesIO

def read_file_name(file):
    data = file.read()
    name_len = struct.unpack('<I', data[0:4])[0]
    name_bytes = data[4:4+name_len]
    
    offset = 5 + name_len
    
    if (len(data) - offset) % 2 != 0:
        offset += 1
    
    return name_bytes.decode("ascii"), offset

def read_folder(path: str):
    return os.listdir(path)

def read_file(file, offset=60):
        file.seek(offset)
        all_bytes = file.read()
        
        return pydub.AudioSegment.from_file(BytesIO(all_bytes), format="raw", frame_rate=22050, channels=1, sample_width=2 )

def converter(input_path: str, output_path: str):
    for file_name in read_folder(input_path):
        file_path = os.path.join(input_path, file_name)
        
        with open(file_path, "rb") as file:
            new_name, offset = read_file_name(file)
            audio = read_file(file, offset)
            
            final_path = os.path.join(output_path, new_name + ".mp3")
            audio.export(final_path, format="mp3")

if __name__ == "__main__":
    if len(sys.argv) < 3:
        print("Usage: converter.py <input folder path> <output folder path")
        sys.exit()
    converter(sys.argv[1], sys.argv[2])