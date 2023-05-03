import threading

def print_message(idx: int):
    thread_id = threading.get_ident()
    print(f"Thread{idx} {thread_id} says hello!")

threads = []
for i in range(10):
    thread = threading.Thread(target=print_message, args=[i])
    threads.append(thread)
    thread.start()

for thread in threads:
    thread.join()
