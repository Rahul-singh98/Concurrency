import threading

counter = 0
lock = threading.Lock()

def increment():
    global counter
    with lock:
        counter += 1
    print(f"Counter value: {counter}")

threads = []
for i in range(10):
    thread = threading.Thread(target=increment)
    thread.start()
    threads.append(thread)

for thread in threads:
    thread.join()

print("All threads completed")
print(f"Final counter value: {counter}")
