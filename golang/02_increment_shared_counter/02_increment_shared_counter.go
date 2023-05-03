package main

import (
	"fmt"
	"sync"
)

var counter int
var mutex sync.Mutex

func increment() {
	mutex.Lock()
	counter++
	mutex.Unlock()
	fmt.Printf("Counter value: %d\n", counter)
}

func main() {
	var wg sync.WaitGroup
	for i := 0; i < 10; i++ {
		wg.Add(1)
		go func() {
			defer wg.Done()
			increment()
		}()
	}
	wg.Wait()

	fmt.Println("All goroutines completed")
	fmt.Printf("Final counter value: %d\n", counter)
}
