﻿using BookManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagement.Infrastructure.Persistence.Configurations;

public class LoanConfiguration : IEntityTypeConfiguration<Loan> {
    public void Configure(EntityTypeBuilder<Loan> builder) {
        builder.HasKey(l => l.Id);

        builder.HasOne(l => l.Book)
               .WithMany()
               .HasForeignKey(l => l.BookId);

        builder.HasOne(l => l.User)
               .WithMany()
               .HasForeignKey(l => l.UserId);
    }
}