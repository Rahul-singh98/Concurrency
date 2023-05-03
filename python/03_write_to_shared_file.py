import threading

def write_to_file(file_name, data):
    with open(file_name, 'a') as f:
        f.write(data + '\n')

def main():
    file_name = 'shared_file.txt'
    threads = []

    for i in range(10):
        t = threading.Thread(target=write_to_file, args=(file_name, f'Thread {i} wrote to file'))
        threads.append(t)
        t.start()

    for t in threads:
        t.join()

if __name__ == '__main__':
    main()
