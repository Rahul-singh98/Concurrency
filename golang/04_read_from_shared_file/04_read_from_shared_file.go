package main

import (
	"fmt"
	"io/ioutil"
	"sync"
)

func readFromSharedFile(file string, wg *sync.WaitGroup) {
	defer wg.Done()

	content, err := ioutil.ReadFile(file)
	if err != nil {
		fmt.Printf("Error reading from file: %v\n", err)
		return
	}

	fmt.Printf("Thread read from file: %s\n", content)
}

func main() {
	file := "shared_file.txt"

	var wg sync.WaitGroup

	for i := 0; i < 10; i++ {
		wg.Add(1)
		go readFromSharedFile(file, &wg)
	}

	wg.Wait()
}
