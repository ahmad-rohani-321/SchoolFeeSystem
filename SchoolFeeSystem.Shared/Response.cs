﻿namespace SchoolFeeSystem.Shared;

public class Response<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
}
