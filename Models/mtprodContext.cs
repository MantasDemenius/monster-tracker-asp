using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace monster_tracker_asp.Models
{
    public partial class mtprodContext : DbContext
    {
        public mtprodContext()
        {
        }

        public mtprodContext(DbContextOptions<mtprodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Monster> Monster { get; set; }
        public virtual DbSet<MonsterActionLink> MonsterActionLink { get; set; }
        public virtual DbSet<MonsterUserAccessibilityLink> MonsterUserAccessibilityLink { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost; port=3306; user=root; password=La.pas201; database=mtprod");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>(entity =>
            {
                entity.ToTable("action", "mtprod");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ability)
                    .IsRequired()
                    .HasColumnName("ABILITY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AttackBonus)
                    .HasColumnName("ATTACK_BONUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DamageBonus)
                    .HasColumnName("DAMAGE_BONUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DamageDice)
                    .HasColumnName("DAMAGE_DICE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SysDeleteStatus)
                    .IsRequired()
                    .HasColumnName("SYS_DELETE_STATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Monster>(entity =>
            {
                entity.ToTable("monster", "mtprod");

                entity.HasIndex(e => e.SkillId)
                    .HasName("SKILL_ID");

                entity.HasIndex(e => e.UserId)
                    .HasName("USER_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Alignment)
                    .HasColumnName("ALIGNMENT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ArmorClass)
                    .HasColumnName("ARMOR_CLASS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ChallengeRating)
                    .HasColumnName("CHALLENGE_RATING")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ConditionImmunity)
                    .HasColumnName("CONDITION_IMMUNITY")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.CreationTime)
                    .HasColumnName("CREATION_TIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.HitDice)
                    .HasColumnName("HIT_DICE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HitPoints)
                    .HasColumnName("HIT_POINTS")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Immunity)
                    .HasColumnName("IMMUNITY")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasColumnName("LANGUAGE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .HasColumnName("PICTURE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PictureAuthor)
                    .HasColumnName("PICTURE_AUTHOR")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Resistance)
                    .HasColumnName("RESISTANCE")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Sense)
                    .HasColumnName("SENSE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasColumnName("SIZE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SkillId)
                    .HasColumnName("SKILL_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Speed)
                    .HasColumnName("SPEED")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SysDeleteStatus)
                    .IsRequired()
                    .HasColumnName("SYS_DELETE_STATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Visibility)
                    .IsRequired()
                    .HasColumnName("VISIBILITY")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vulnerability)
                    .HasColumnName("VULNERABILITY")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.Monster)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("monster_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Monster)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("monster_ibfk_1");
            });

            modelBuilder.Entity<MonsterActionLink>(entity =>
            {
                entity.HasKey(e => new { e.MonsterId, e.ActionId });

                entity.ToTable("monster_action_link", "mtprod");

                entity.HasIndex(e => e.ActionId)
                    .HasName("ACTION_MONSTER_LINK");

                entity.Property(e => e.MonsterId)
                    .HasColumnName("MONSTER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActionId)
                    .HasColumnName("ACTION_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.MonsterActionLink)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ACTION_MONSTER_LINK");

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.MonsterActionLink)
                    .HasForeignKey(d => d.MonsterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MONSTER_ACTION_LINK");
            });

            modelBuilder.Entity<MonsterUserAccessibilityLink>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MonsterId });

                entity.ToTable("monster_user_accessibility_link", "mtprod");

                entity.HasIndex(e => e.MonsterId)
                    .HasName("USER_MONSTER_ACCESSIBILITY_LINK");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MonsterId)
                    .HasColumnName("MONSTER_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.MonsterUserAccessibilityLink)
                    .HasForeignKey(d => d.MonsterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USER_MONSTER_ACCESSIBILITY_LINK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MonsterUserAccessibilityLink)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MONSTER_USER_ACCESSIBILITY_LINK");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("score", "mtprod");

                entity.HasIndex(e => e.MonsterId)
                    .HasName("MONSTER_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Charisma)
                    .HasColumnName("CHARISMA")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Constitution)
                    .HasColumnName("CONSTITUTION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Dexterity)
                    .HasColumnName("DEXTERITY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Intelligence)
                    .HasColumnName("INTELLIGENCE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MonsterId)
                    .HasColumnName("MONSTER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ScoreTypeCode)
                    .HasColumnName("SCORE_TYPE_CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Strength)
                    .HasColumnName("STRENGTH")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SysDeleteStatus)
                    .IsRequired()
                    .HasColumnName("SYS_DELETE_STATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Wisdom)
                    .HasColumnName("WISDOM")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.Score)
                    .HasForeignKey(d => d.MonsterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("score_ibfk_1");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill", "mtprod");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Acrobatics)
                    .HasColumnName("ACROBATICS")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnimalHandling)
                    .HasColumnName("ANIMAL_HANDLING")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Arcana)
                    .HasColumnName("ARCANA")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Athletics)
                    .HasColumnName("ATHLETICS")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Deception)
                    .HasColumnName("DECEPTION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.History)
                    .HasColumnName("HISTORY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Insight)
                    .HasColumnName("INSIGHT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Intimidation)
                    .HasColumnName("INTIMIDATION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Investigation)
                    .HasColumnName("INVESTIGATION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Medicine)
                    .HasColumnName("MEDICINE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nature)
                    .HasColumnName("NATURE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Perception)
                    .HasColumnName("PERCEPTION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Performance)
                    .HasColumnName("PERFORMANCE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Persuasion)
                    .HasColumnName("PERSUASION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Religion)
                    .HasColumnName("RELIGION")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SleightOfHand)
                    .HasColumnName("SLEIGHT_OF_HAND")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Stealth)
                    .HasColumnName("STEALTH")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Survival)
                    .HasColumnName("SURVIVAL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SysDeleteStatus)
                    .IsRequired()
                    .HasColumnName("SYS_DELETE_STATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("type", "mtprod");

                entity.HasIndex(e => e.MonsterId)
                    .HasName("MONSTER_ID");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MonsterId)
                    .HasColumnName("MONSTER_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SysDeleteStatus)
                    .IsRequired()
                    .HasColumnName("SYS_DELETE_STATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasColumnName("TYPE_CODE")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.Type)
                    .HasForeignKey(d => d.MonsterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("type_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "mtprod");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Passwordhash)
                    .IsRequired()
                    .HasColumnName("PASSWORDHASH")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Passwordsalt)
                    .IsRequired()
                    .HasColumnName("PASSWORDSALT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SysDeleteStatus)
                    .IsRequired()
                    .HasColumnName("SYS_DELETE_STATUS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
