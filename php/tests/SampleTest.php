<?php

use PHPUnit\Framework\TestCase;
use App\Sample;

class SampleTest extends TestCase
{
    public function testGreet()
    {
        $sample = new Sample();
        $this->assertEquals("Hello, John!", $sample->greet("John"));
    }

    public function testGreetWithEmptyName()
    {
        $sample = new Sample();
        $this->assertEquals("Hello, !", $sample->greet(""));
    }

    public function testGreetWithNullName()
    {
        $sample = new Sample();
        $this->assertEquals("Hello, !", $sample->greet(null));
    }
}
