import threading

def read_from_shared_file(file):
    with open(file, "r") as f:
        print("Thread {} read from file: {}".format(threading.current_thread().name, f.read()))

if __name__ == '__main__':
    file = "shared_file.txt"

    for i in range(10):
        t = threading.Thread(target=read_from_shared_file, args=(file,))
        t.start()
