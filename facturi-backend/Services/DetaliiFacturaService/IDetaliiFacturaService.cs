﻿using facturi_backend.Models.DTOs;

namespace facturi_backend.Services.DetaliiFacturaService
{
    public interface IDetaliiFacturaService
    {
        DetaliiFacturaResponseDTO? GetDetaliiFacturaById(int id);
        DetaliiFacturaResponseDTO? GetDetaliiFacturaByFacturaId(int id);
        void UpdateDetaliiFactura(int id, DetaliiFacturaReceiveDTO payload);
    }
}
