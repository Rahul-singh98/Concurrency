package main

import (
	"fmt"
	"os"
	"sync"
)

func writeToSharedFile(file *os.File, wg *sync.WaitGroup, message string) {
	defer wg.Done()
	if _, err := fmt.Fprintln(file, message); err != nil {
		fmt.Println("Error writing to file:", err)
	}
}

func main() {
	file, err := os.Create("shared_file.txt")
	if err != nil {
		fmt.Println("Error creating file:", err)
		return
	}
	defer file.Close()

	var wg sync.WaitGroup
	for i := 0; i < 10; i++ {
		wg.Add(1)
		go writeToSharedFile(file, &wg, fmt.Sprintf("Thread %d wrote to file", i))
	}

	wg.Wait()
	fmt.Println("All threads finished writing to file.")
}
